
/*************************************************************************************

  Kevin Lo, March 2015

  This program will show PH , Room Temperature and Water Temperature on the LCD panel.
  Also support serial communication.
 
  Connection: 
  1) Plug the LCD Keypad to the UNO
  2) Connect Arduino D2 to PH Meter Board T2 (DS18B20)
  3) Connect Arduino A1 to PH Meter Board T1 (LM35)
  4) Connect Arduino A2 to PH Meter Board P0 (PH)
  5) Connect Arduino 5V to PH Meter Board Vcc
  6) Connect Arduino GND to PH Meter Board GND
  
  Require Library :
  LiquidCrystal : http://arduino.cc/en/Reference/LiquidCrystal
  OneWire : http://www.pjrc.com/teensy/td_libs_OneWire.html
  DallasTemperature : http://milesburton.com/Dallas_Temperature_Control_Library

  Serial Communication :
  Send command in HEX format . 
  AA 01 01 BB , Enquiry DS18B20 temperature
  AA 01 02 BB , Enquiry LM35 temperature
  AA 01 03 BB , Enquiry PH reading
  AA 01 04 BB , Enqyiry DS18B20 , LM35 and Ph

  Version :
  v0.1 5/3/2015    First Version 

**************************************************************************************/

#include <LiquidCrystal.h>
#include <OneWire.h>
#include <DallasTemperature.h>

LiquidCrystal lcd(8, 9, 4, 5, 6, 7);           // select the pins used on the LCD panel
#define ONE_WIRE_BUS 2                         // DS18B20 connect to Pin 2 

OneWire oneWire(ONE_WIRE_BUS);
DallasTemperature sensors(&oneWire);

#define STX 0xAA                                // define STX for serial communication
#define ETX 0XBB                                // define ETX for serial communication

byte RxCmd [4] = {0,0,0,0};

// define some values used by the panel and buttons
int lcd_key     = -1;
int adc_key_in  = 0;
int adc_key_prev  = -1;
int CurrentMode = 0;                           // 0 = Normal Display , 1 = Debug1 , 2 = Debug2
int CalSelect = 0;                             // 0 = PH4 Calibration Select , 1 = PH7 Calibration Select

const int NumReadings = 10;                    // number of reading for LM35
int Index = 0;                                 // index
int TempReadings[NumReadings];                 // array for store LM35 readings
int TempTotal = 0;                             // LM35 running total
int TempAverage = 0;                           // LM35 average reading
double TempValue = 0;                          // LM35 Temperature Data in Human Reading Format after calculation

int PhReadings[NumReadings];                   // array for store PH readings
int PhTotal = 0;                               // PH running total
int PhAverage = 0;                             // PH average reading

double Ph7Buffer = 6.86;                          // For PH7 buffer solution's PH value , 7 or 6.86
double Ph4Buffer = 4.01;                       // For PH4 buffer solution's PH value , 4 or 4.01

double Ph7Reading = 528;                       // PH7 Buffer Solution Reading.
double Ph4Reading = 655;                       // PH4 Buffer Solution Reading.

double PhRatio = 0;                            // PH Step
double PhValue = 0;                            // Ph Value in Human Reading Format after calculation

#define btnRIGHT  0
#define btnUP     1
#define btnDOWN   2
#define btnLEFT   3
#define btnSELECT 4
#define btnNONE   5

int read_LCD_buttons(){                        // read the buttons
    adc_key_in = analogRead(0);                // read the value from the sensor 
    delay(10);                                 // switch debounce delay. Increase this delay if incorrect switch selections are returned.
    int k = (analogRead(0) - adc_key_in);      // gives the button a slight range to allow for a little contact resistance noise
    if (5 < abs(k)) return btnNONE;            // double checks the keypress. If the two readings are not equal +/-k value after debounce delay, it tries again.
    //lcd.print(adc_key_in);                   // read button value and print for calibrate 
    
    // my buttons when read are centered at these valies: 0, 144, 329, 504, 741
    // we add approx 50 to those values and check to see if we are close
    // We make this the 1st option for speed reasons since it will be the most likely result

    if (adc_key_in > 1000) return btnNONE; 
    if (adc_key_in < 50)   return btnRIGHT;  
    if (adc_key_in < 150)  return btnUP; 
    if (adc_key_in < 350)  return btnDOWN; 
    if (adc_key_in < 550)  return btnLEFT; 
    if (adc_key_in < 750)  return btnSELECT;  
    return btnNONE;                // when all others fail, return this.
}

int reading(){                                   // Reading LM35 and PH Data
   // Samplin LM35 and PH Value
  TempTotal= TempTotal - TempReadings[Index];    // subtract the last reading:       
  PhTotal= PhTotal - PhReadings[Index];          // subtract the last reading:       
  TempReadings[Index] = analogRead(1);           // read from the sensor : LM35  
  PhReadings[Index] = analogRead(2);             // read from the sensor : PH 
  TempTotal= TempTotal + TempReadings[Index];    // add the reading to the temperature total:     
  PhTotal= PhTotal + PhReadings[Index];          // add the reading to the ph total:     
  Index = Index + 1;                             // advance to the next position in the array:                

  if (Index >= NumReadings){                     // if we're at the end of the array...         
  Index = 0;                                     // ...wrap around to the beginning:                         
  TempAverage = TempTotal / NumReadings;         // calculate the average:
  PhAverage = PhTotal / NumReadings;             // calculate the average:
  }
  TempValue = (double) TempAverage / 3.4  * (5/10.24);   // LM35 connect to CA3140 for amplify 3 time
  PhValue = (Ph7Reading - PhAverage) / PhRatio + Ph7Buffer;    // Calculate PH
  
}

void setup(){
   lcd.begin(16, 2);                                                                // start LCD library
    
   for (int TempThisReading = 0; TempThisReading < NumReadings; TempThisReading++)  // initialize all the LM35 readings to 0:
   TempReadings[TempThisReading] = 0; 
   
   for (int PhThisReading = 0; PhThisReading < NumReadings; PhThisReading++)        // initialize all the Ph readings to 0:
   PhReadings[PhThisReading] = 0; 
   
   PhRatio = (Ph4Reading - Ph7Reading) / (Ph7Buffer - Ph4Buffer);                 // Calculate Ph Ratio 
      
   Serial.begin(9600);
   while(Serial.available()) Serial.read();                                          // empty RX buffer
   Serial.println("Starting");
}
 
void loop(){

  if (Serial.available()) {
   delay(2);
    RxCmd[0] = Serial.read(); 
    if (RxCmd[0] == STX) {
        int i =1;
      while(Serial.available()) {
        delay(1);
        RxCmd[i] = Serial.read();
        //if (RxCmd[i]>127 || i>7)      break;                                    //Communication error
        if (RxCmd[i]==ETX) {
          break;                                                                  //Read all data 
        }
        i++;
      }
    }
  }
  
if ( RxCmd[1] == 1 ){
  lcd.setCursor(9,1);
  switch (RxCmd[2]) {
    case 1:{
      //Serial.print("Command 1 Received ");              // Enquiry Water Temperature (DS18B20)
      Serial.println(sensors.getTempCByIndex(0),2);       // Return DS18B20 Data
      break;
    }
    case 2:{
      //Serial.print("Command 2 Received ");              // Enquiry Room Temperature (LM35)
      Serial.println(TempValue,2);                        // Return LM35 Data
      break;
    }
    case 3:{
      //Serial.print("Command 3 Received ");              // Enquiry PH Data
      Serial.println(PhValue,2);                          // Return PH Data
      break;
    }
    case 4:{
      //Serial.println("Command 4 Received ");           // Enquiry Water Temp. & Room Temp. & PH
      Serial.println(sensors.getTempCByIndex(0),2);       // Return DS18B20 Data 
      Serial.println(TempValue,2);                        // Return LM35 Data
      Serial.println(PhValue,2);                          // Return PH Data
      break;
    }
  }
}
  
  for (int i = 0 ; i < 5 ; i++) {
    RxCmd[i] = 0;
  }
  
if (CurrentMode == 0)                        // Nomral Display Mode
{
  reading();                                 // Reading LM35 and PH Data for display 
  lcd.setCursor(13,0);
  lcd.print("PH ");
  lcd.setCursor(0,0);                        // set the LCD cursor position 
  lcd.print("Room");  
  lcd.setCursor(0,1);
  lcd.print("Water");  
  lcd.setCursor(6,0);
  lcd.print(TempValue);                      // display room temperature value (LM35)
  delay(1);                                  // delay in between reads for stability     
   
  // Display 18B20 Temperature
  lcd.setCursor(6,1);                       // move cursor to second line "1" and 6 spaces over
  sensors.requestTemperatures();            // Read DS18B20 data
  lcd.print(sensors.getTempCByIndex(0));    // Display DS18B20 Data

  // Display PH Data 
  lcd.setCursor(13,0);
  lcd.print("PH");
  lcd.setCursor(12,1);
  lcd.print(PhValue);                        // display PH value
  delay(1);                                  // delay in between reads for stability   

}

if (CurrentMode == 1){
  reading();
  lcd.setCursor(0,0);
  lcd.print("LM35 R");
  lcd.setCursor(10,0);
  lcd.print("T");
  lcd.setCursor(0,1);
  lcd.print("PH   R");
  lcd.setCursor(10,1);
  lcd.print("P");

  lcd.setCursor(6,0);
  lcd.print(TempAverage);
  lcd.setCursor(12,0);
  lcd.print(TempValue);
  
  lcd.setCursor(6,1);
  lcd.print(PhAverage);
  lcd.setCursor(11,1);
  lcd.print(PhValue);
}

if (CurrentMode == 2){
  reading();
  double PhVoltage;
  PhVoltage = (double)PhAverage * (5/10.24);
  
  lcd.setCursor(0,0);
  lcd.print("R:");
  lcd.setCursor(3,0);
  lcd.print(PhAverage);
  

  lcd.setCursor(7,0);
  lcd.print("Ratio:");
  lcd.setCursor(13,0);
  lcd.print(PhRatio);

  lcd.setCursor(0,1);
  lcd.print("PH:");
  lcd.setCursor(3,1);
  lcd.print(PhValue);    
}

if (CurrentMode == 3){          // Calibration Mode Selection Page
  lcd.setCursor(0,0);
  lcd.print("PH4 Cal ");
  lcd.setCursor(0,1);
  lcd.print("PH7 Cal ");
  if (CalSelect == 0) {
      lcd.setCursor(8,0);
      lcd.print(">>");
   }
  if (CalSelect == 1) {
      lcd.setCursor(8,1);
      lcd.print(">>");
   }
}

if (CurrentMode == 4){            // PH4 Calibration Mode
  reading();
  lcd.setCursor(0,0);
  lcd.print("PH4 Cal. Mode");
  lcd.setCursor(0,1);
  lcd.print("C:");
  lcd.setCursor(2,1);
  lcd.print(Ph4Reading);
  lcd.setCursor(9,1);
  lcd.print("R:");
  lcd.setCursor(11,1);
  lcd.print(PhAverage);
}

if (CurrentMode == 5){            // PH7 Calibration Mode
  reading();
  lcd.setCursor(0,0);
  lcd.print("PH7 Cal. Mode");
  lcd.setCursor(0,1);
  lcd.print("C:");
  lcd.setCursor(2,1);
  lcd.print(Ph7Reading);
  lcd.setCursor(9,1);
  lcd.print("R:");
  lcd.setCursor(11,1);
  lcd.print(PhAverage);
}


   lcd.setCursor(0,1);             // move to the begining of the second line
   adc_key_prev = lcd_key ;       // Looking for changes

   lcd_key = read_LCD_buttons();   // read the buttons

  if (adc_key_prev != lcd_key)
  {
   //Serial.println("Key Press Change Detected");
   switch (lcd_key){               // depending on which button was pushed, we perform an action
       case btnRIGHT:{             //  push button "RIGHT" and show the word on the screen
            //lcd.print("RIGHT");
            if ( CurrentMode == 0 ){
               lcd.clear();
               CurrentMode = 2;
             }
            if ( CurrentMode == 3){
               lcd.clear();
               if ( CalSelect == 0 ){
                 CurrentMode = 4;
               } 
               if ( CalSelect == 1){
                 CurrentMode = 5;
               }
            }
            break;
       }
       case btnLEFT:{
             //lcd.print("LEFT "); //  push button "LEFT" and show the word on the screen
             if ( CurrentMode == 2 ){
               lcd.clear();
               CurrentMode = 0;
             }
             if ( CurrentMode == 3 ){
               lcd.clear();
               CurrentMode = 0;
             }
             if ( CurrentMode == 4 || CurrentMode == 5 ){
               lcd.clear();
               CurrentMode = 3;
             }

             break;
       }    
       case btnUP:{
             //lcd.print("UP   ");  //  push button "UP" and show the word on the screen
             if ( CurrentMode == 0 ){
               lcd.clear();
               CurrentMode = 1;
             }
             if ( CurrentMode == 3 ){
               lcd.clear();
               CalSelect = 0;
             }
             break;
       }
       case btnDOWN:{
             //lcd.print("DOWN ");  //  push button "DOWN" and show the word on the screen
             if ( CurrentMode == 1){
               lcd.clear();
               CurrentMode = 0;
             }
             if ( CurrentMode == 3 ){
               lcd.clear();
               CalSelect = 1;
             }
             break;
       }
       case btnSELECT:{
             //lcd.print("SEL. ");  //  push button "SELECT" and show the word on the screen
             if ( CurrentMode == 0 ){
               lcd.clear();
               CurrentMode = 3;
               break;
             }
             if ( CurrentMode == 3 ){
               lcd.clear();
               CurrentMode = 0;
               break;
             }
               break;

       }
       case btnNONE:{
             //lcd.print("NONE ");  //  No action  will show "None" on the screen
             break;
       }
     }
   }
}

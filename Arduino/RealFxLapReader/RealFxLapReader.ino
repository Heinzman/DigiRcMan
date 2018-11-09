#include <SPI.h>
#include "MFRC522.h"
#include "QueueList.h"

#define SS_PIN 10    
#define RST_PIN 9

MFRC522 mfrc522(SS_PIN, RST_PIN);        // Create MFRC522 instance.

const byte mrfcId = 1;

const long tagIdSendInterval = 500;  // interval at which to send tagId (milliseconds)
const int ledPin =  5;  // the number of the LED pin
const long ledBlinkInterval = 1000; // interval at which to blink (milliseconds)
const int lengthOfSingleDataRow = 6;

unsigned long previousTagIdSendMillis = 0;        // will store last time a TagId was detected
unsigned long previousLedBlinkMillis = 0;        // will store last time LED was updated
byte previousIdsBuffer[3];
byte currentIdsBuffer[3];
QueueList<byte> serialDataInQueue;

void setup() {
  Serial.begin(9600);        
  SPI.begin();               
  mfrc522.PCD_Init();       
  mfrc522.PCD_SetAntennaGain(mfrc522.RxGain_max);

  pinMode(ledPin, OUTPUT);
  digitalWrite(ledPin, LOW);
  serialDataInQueue.setPrinter(Serial);
}

void loop() {
  byte serialDataIn;  
  
  while (Serial.available()>0){
    serialDataIn = Serial.read(); 

    if (serialDataIn == 0xFF || serialDataInQueue.count() > 0) {
      serialDataInQueue.push(serialDataIn);
    }
  }

  while (serialDataInQueue.count() >= lengthOfSingleDataRow) {
    TurnLedOn();
    byte buffer[6];

    for (int i=0; i<lengthOfSingleDataRow; i++) {
      buffer[i] = serialDataInQueue.pop();
    }   
    Serial.write(buffer, sizeof(buffer));  

    while (serialDataInQueue.count() > 0 && serialDataInQueue.peek() != 0xFF) {
      serialDataInQueue.pop();
    }
  }

  if (mfrc522.PICC_IsNewCardPresent() && mfrc522.PICC_ReadCardSerial()) {
    bool isIdDifferentToPrevious = false;
    
    for (byte i = 0; i < 3; i++) {      
      currentIdsBuffer[i] = mfrc522.uid.uidByte[i];
      if (currentIdsBuffer[i] != previousIdsBuffer[i]) {
        isIdDifferentToPrevious = true;
      }
    } 

    if (isIdDifferentToPrevious || (millis() - previousTagIdSendMillis >= tagIdSendInterval)) {
      previousTagIdSendMillis = millis();  
      TurnLedOn();
      
      byte buffer[6];
      buffer[0] = 0xFF;
      buffer[1] = 0xD2;
      buffer[2] = mrfcId;
      
      for (byte i = 0; i < 3; i++) {         
        buffer[i+3] = currentIdsBuffer[i];
        previousIdsBuffer[i] = currentIdsBuffer[i];
      } 
      Serial.write(buffer, sizeof(buffer));  
    }    
  }
  CheckToTurnLedOff();
}

void TurnLedOn() {
  digitalWrite(ledPin, HIGH);
  previousLedBlinkMillis = millis();  
}

void CheckToTurnLedOff() {
  if (millis() - previousLedBlinkMillis >= ledBlinkInterval) 
    digitalWrite(ledPin, LOW);
}
  

#include <SoftwareSerial.h>

SoftwareSerial BTSerial(10, 11); // RX, TX

int sensorPin = A0; // Pin analógico al que está conectado el sensor
int sensorValue = 0;
void setup() {
  Serial.begin(9600);
  BTSerial.begin(9600);
}

void loop() {
  sensorValue = analogRead(sensorPin);
  float temperature = sensorValue * (5.0 / 1023.0) * 100.0; // Conversión a grados Celsius
  BTSerial.println(temperature); // Enviar la temperatura por Bluetooth
  Serial.println(temperature);
  delay(1000); // Esperar 1 segundo antes de la siguiente lectura
}

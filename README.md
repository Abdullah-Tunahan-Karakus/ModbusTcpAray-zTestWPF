#  Modbus TCP Kontrol Paneli (WPF)

Bu depo, endüstriyel otomasyon sistemleri için C# ve XAML (Windows Presentation Foundation - WPF) kullanılarak geliştirilmiş, vektörel tabanlı ve modern bir SCADA (Danışmalı Kontrol ve Veri Toplama) arayüzüdür. Sahadaki cihazların (PLC vb.) durumunu izlemek ve komut göndermek için tasarlanmıştır.

>  **BAĞIMLILIK UYARISI:**
> Bu SCADA panelinin haberleşme motoru, mimarisi tarafımca kurulan **Modbus TCP Kütüphanesidir**. Projeyi çalıştırabilmek için öncelikle ana haberleşme kütüphanesini indirip referans olarak projeye dahil etmeniz gerekmektedir.
>  **[Modbus TCP Core Library Reposuna Git](https://github.com/Abdullah-Tunahan-Karakus/ModbusTcpLibrary)**

---

##  SCADA Paneli Görüntüsü

![WPF Test Ekranı]<img width="786" height="766" alt="TCPWPFEkran" src="https://github.com/user-attachments/assets/aee6aba5-ad55-402c-a987-8ddafb7fdb1a" />
![Simülasyon Test Ekranı]<img width="406" height="551" alt="test için sımulasyon ekran gor " src="https://github.com/user-attachments/assets/66ca7eb6-5fff-4d25-bb21-a4e7885c3a8c" />


---

##  Öne Çıkan Özellikler
* **Modern ve Esnek Tasarım (XAML):** Endüstriyel standartlara uygun, temiz (clean) ve kullanıcı dostu görsel panel.
* **Non-Blocking UI (Asenkron İşlemler):** Arka planda çalışan ağ görevleri sırasında operatör panelinde hiçbir donma veya gecikme yaşanmaz.
* **Register İzleme (FC 03):** Sahadan gelen verileri okuma ve görselleştirme.
* **Operatör Komutları (FC 06):** Sahadaki cihazlara anlık, tekil parametre (setpoint) gönderme.
* **Reçete ve Batch Gönderimi (FC 16):** Birden fazla sistem parametresini tek seferde sahaya fırlatma yeteneği.
* **Gerçek Zamanlı Loglama:** Bağlantı durumunu ve veri paketlerini anlık raporlayan sistem paneli.

---

## 👨‍💻 Geliştirici
**Abdullah Tunahan Karakuş**  
*Bilgisayar Mühendisi* | *Endüstriyel Haberleşme & Yazılım Mimarileri*

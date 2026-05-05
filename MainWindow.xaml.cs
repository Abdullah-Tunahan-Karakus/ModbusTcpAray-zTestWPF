using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ModbusTcpKutuphanesi.ModbusMaster;

namespace ModbusTcpArayüzTestWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ModbusTcpMaster plc = new ModbusTcpMaster();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                plc.Connect(txtIp.Text, Convert.ToInt32(txtPort.Text));
                LogYaz($"[SYSTEM] {txtIp.Text}:{txtPort.Text} adresine bağlanıldı.");
            }
            catch(Exception ex)
            { 
                MessageBox.Show("Bağlantı Hatası: "+ex.Message );
            }
        }
        private void btnDisconnect_Click(object sender, RoutedEventArgs e)
        {
            plc.Disconnect();
            LogYaz("[SYSTEM] Bağlantı kesildi");
        }

        private async void btnRead_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int startAddress = Convert.ToInt32(txtReadAddress.Text);
                int quantity = Convert.ToInt32(txtReadQuantatiy.Text);
                int[] receivedData = await plc.ReadHoldingRegistersAsync(1, startAddress, quantity);
                LogYaz($"[READ SUCCESS] Adres: {startAddress}, Adet: {quantity}");
                for(int i = 0; i < receivedData.Length ; i++)
                {
                    LogYaz($"  -> {startAddress + i}: {receivedData[i]}");
                }
                LogYaz("---------");
            }
            catch (Exception ex)
            {
                LogYaz($"[READ ERROR] {ex.Message}");
            }
        }

        private async void btnWriteSingle_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                int address = Convert.ToInt32(txtWriteSingleAddress.Text);
                int value = Convert.ToInt32(txtWriteSingleValue.Text);

                bool success = await plc.WriteSingleRegistersAsync(1, address, value);
                if (success) LogYaz($"[WRITE SUCCESS] Adres: {address} , Değer: {value}");
            }
            catch(Exception ex) 
            {
                LogYaz($"[WRITE ERROR] {ex.Message}");
            }
        }

        private async void btnWriteMulti_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int  startAddress=Convert.ToInt32(txtWriteMultiAddress.Text);
                int[] valuesToWrite = txtWriteMultiValues.Text.Split(',')
                                                              .Select(val=>Convert.ToInt32(val.Trim()))
                                                              .ToArray();
                bool success = await plc.WriteMultipleRegistersAsync(1, startAddress, valuesToWrite);
                if (success) LogYaz($"[MULTI WRITE SUCCESS] Adres: {startAddress},Gönderilenler: [{txtWriteMultiValues.Text}]");
            }
            catch(Exception ex)
            {
                LogYaz($"[MULTI WRITE ERROR] {ex.Message}");
            }
        }

        private void LogYaz(string mesaj)
        {
            txtLog.AppendText(mesaj + "\r\n");
            txtLog.ScrollToEnd();
        }
    }
}
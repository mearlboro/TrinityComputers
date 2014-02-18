using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;

namespace WebStore
{

    public class Hardware
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        private string manufacturer;
        public string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }
        private string series;
        public string Series
        {
            get { return series; }
            set { series = value; }
        }
        private float price;
        public float Price
        {
            get { return price; }
            set { price = value; }
        }
        private int stock;
        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }
        private int warranty;
        public int Warranty
        {
            get { return warranty; }
            set { warranty = value; }
        }

        public Hardware()
        { }

        public Hardware(string[] item)
        {
            ID = int.Parse(item[0]);
            Manufacturer = item[1];
            Series = item[2];
            Price = float.Parse(item[3]);
            Stock = int.Parse(item[4]);
            Warranty = int.Parse(item[5]);
        }

        public void display(Label l)
        {
            l.Text = Manufacturer + " " + Series + "<br/>Price: " + Price + " £<br/>Warranty: " + Warranty + " months<br/>";
        }

        public int compare(Hardware p)
        {
            if (p.Price <Price)
                return 1;
            else if (p.Price > Price)
                return 2;
            else return 0;
        }
    };


    public class Processor : Hardware //COD 1-
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private float frecventa;
        public float Frecventa
        {
            get { return frecventa; }
            set { frecventa = value; }
        }
        private string socket;
        public string Socket
        {
            get { return socket; }
            set { socket = value; }
        }
        private int nuclee;
        public int Nuclee
        {
            get { return nuclee; }
            set { nuclee = value; }
        }

        public Processor()
        { }

        public Processor(string[] item)
        {
            ID = int.Parse(item[0]);
            Manufacturer = item[1];
            Series = item[2];
            Price = float.Parse(item[3]);
            Stock = int.Parse(item[4]);
            Warranty = int.Parse(item[5]);
            Name = item[6];
            Frecventa = float.Parse(item[7]);
            Socket = item[8];
            Nuclee = int.Parse(item[9]);
        }

        public void show(Label l)
        {
            l.Text = Manufacturer + " " + Name + " " + Series + "<br/>Price: " + Price + " £<br/>Warranty " + Warranty + " months<br/>" + Nuclee + " cores, " + Frecventa + "MHz<br/>Socket: " + Socket + "<br/><br/><br/><br/>";
        }

        public bool compatibilitate(Motherboard placa)
        {
            if (placa.SocketProcesor == Socket)
                return true;
            return false;
        }

         public int Compare(Processor p)
        {
            float a = p.Frecventa * p.Nuclee;
            float b = Frecventa * Nuclee;
            if (a < b)
                return 1;
            else if (a > b) return 2;
            else return 0;
        }
    };

    public class Motherboard : Hardware //COD 2-
    {
        private string socketProcesor;
        public string SocketProcesor
        {
            get { return socketProcesor; }
            set { socketProcesor = value; }
        }
        private string slotVideo;
        public string SlotVideo
        {
            get { return slotVideo; }
            set { slotVideo = value; }
        }
        private string memorieSuportata;
        public string MemorieSuportata
        {
            get { return memorieSuportata; }
            set { memorieSuportata = value; }
        }
        private int sloturiRAM;
        public int SloturiRAM
        {
            get { return sloturiRAM; }
            set { sloturiRAM = value; }
        }
        private int porturiUSB;
        public int PorturiUSB
        {
            get { return porturiUSB; }
            set { porturiUSB = value; }
        }
        private bool videoIntegrat;
        public bool VideoIntegrat
        {
            get { return videoIntegrat; }
            set { videoIntegrat = value; }
        }
        private bool audioIntegrat;
        public bool AudioIntegrat
        {
            get { return audioIntegrat; }
            set { audioIntegrat = value; }
        }
        private bool lANIntegrat;
        public bool LANIntegrat
        {
            get { return lANIntegrat; }
            set { lANIntegrat = value; }
        }

        public Motherboard()
        { }
        public Motherboard(string[] item)
        {
            ID = int.Parse(item[0]);
            Manufacturer = item[1];
            Series = item[2];
            Price = float.Parse(item[3]);
            Stock = int.Parse(item[4]);
            Warranty = int.Parse(item[5]);
            
            SocketProcesor = item[6];
            SlotVideo = item[7];
            MemorieSuportata = item[8];
            SloturiRAM = int.Parse(item[9]);
            PorturiUSB = int.Parse(item[10]);
            VideoIntegrat = bool.Parse(item[11]);
            AudioIntegrat = bool.Parse(item[12]);
            LANIntegrat = bool.Parse(item[13]);
        }
        public void show(Label l)
        {
            l.Text = Manufacturer + " " + Series + "<br/>Price: " + Price + " £<br/>Warranty " + Warranty + " months <br/>Socket: " + SocketProcesor + "<br/>" + "GPU Slot: " + SlotVideo + "<br/>RAM: " + SloturiRAM + " slots, " + MemorieSuportata + "<br/>" + PorturiUSB + " USB ports<br/><br/>"; 
        }

        public int Compare(Motherboard p)
        {
            if (SloturiRAM > p.SloturiRAM)
                return 1;
            else if (SloturiRAM < p.SloturiRAM) return 2;
            else return 0;
        }
    };

    public class SoundCard : Hardware //COD 3-
    {
        private string nume;
        public string Nume
        {
            get { return nume; }
            set { nume = value; }
        }
        private int rezolutieAudio;
        public int RezolutieAudio
        {
            get { return rezolutieAudio; }
            set { rezolutieAudio = value; }
        }

        public SoundCard()
        { }
        public SoundCard(string[] item)
        {
            ID = int.Parse(item[0]);
            Manufacturer = item[1];
            Series = item[2];
            Price = float.Parse(item[3]);
            Stock = int.Parse(item[4]);
            Warranty = int.Parse(item[5]);
            Nume = item[6];
            RezolutieAudio = int.Parse(item[7]);
        }

        public void show(Label l)
        {
            l.Text = Manufacturer + " " + Nume + " " + Series + "<br/>Price: " + Price + " £<br/>Warranty " + Warranty + " months<br/>Rezolution: " + RezolutieAudio + "bits<br/><br/><br/><br/>";
        }
        public int Compare(SoundCard p)
        {
            if (RezolutieAudio > p.RezolutieAudio)
                return 1;
            else if (RezolutieAudio < p.RezolutieAudio) return 2;
            else return 0;
        }
    }

    public class PowerSupplyUnit : Hardware//COD 4-
    {
        private float putere;
        public float Putere
        {
            get { return putere; }
            set { putere = value; }
        }
        private int numarVentilatoare;
        public int NumarVentilatoare
        {
            get { return numarVentilatoare; }
            set { numarVentilatoare = value; }
        }

        public PowerSupplyUnit()
        { }
        public PowerSupplyUnit(string[] item)
        {
            ID = int.Parse(item[0]);
            Manufacturer = item[1];
            Series = item[2];
            Price = float.Parse(item[3]);
            Stock = int.Parse(item[4]);
            Warranty = int.Parse(item[5]);
            Putere = float.Parse(item[6]);
            NumarVentilatoare = int.Parse(item[7]);
        }

        public void show(Label l)
        {
            l.Text = Manufacturer + " " + Series + "<br/>Price: " + Price + " £<br/>Warranty " + Warranty + " months<br/>Power: " + Putere + "W<br/> " + NumarVentilatoare + " fans<br/><br/>";

        }

        public int Compare(PowerSupplyUnit p)
        {
            if (Putere > p.Putere)
                return 1;
            else if (Putere < p.Putere) return 2;
            else return 0;
        }
    }

    public class RAM : Hardware//COD 5-
    {
        private float memorie;
        public float Memorie
        {
            get { return memorie; }
            set { memorie = value; }
        }
        private string tipMemorie;
        public string TipMemorie
        {
            get { return tipMemorie; }
            set { tipMemorie = value; }
        }

        public RAM()
        { }
        public RAM(string[] item)
        {
            ID = int.Parse(item[0]);
            Manufacturer = item[1];
            Series = item[2];
            Price = float.Parse(item[3]);
            Stock = int.Parse(item[4]);
            Warranty = int.Parse(item[5]);
            Memorie = float.Parse(item[6]);
            TipMemorie = item[7];
        }

        public void show(Label l)
        {
            l.Text = Manufacturer + " " + Series + "<br/>Price: " + Price + " £<br/>Warranty " + Warranty + " months<br/>Memory " + Memorie + "MB " + TipMemorie + "<br/><br/><br/><br/>";
        }

        public bool compatibilitate(Motherboard placa)
        {
            if (placa.MemorieSuportata == tipMemorie)
                return true;
            return false;
        }

        public int Compare(RAM p)
        {
            if (Memorie>p.Memorie)
                return 1;
            else if (Memorie < p.Memorie) return 2;
            else return 0;
        }
    }

    public class PlacaVideo : Hardware//COD 6-
    {
        private string nume;
        private string Nume
        {
            get { return nume; }
            set { nume = value; }
        }
        private float memorie;
        public float Memorie
        {
            get { return memorie; }
            set { memorie = value; }
        }
        private string tipMemorie;
        public string TipMemorie
        {
            get { return tipMemorie; }
            set { tipMemorie = value; }
        }
        private string slot;
        public string Slot
        {
            get { return slot; }
            set { slot = value; }
        }
        private int directX;
        public int DirectX
        {
            get { return directX; }
            set { directX = value; }
        }

        public PlacaVideo()
        { }
        public PlacaVideo(string[] item)
        {
            ID = int.Parse(item[0]);
            Manufacturer = item[1];
            Series = item[2];
            Price = float.Parse(item[3]);
            Stock = int.Parse(item[4]);
            Warranty = int.Parse(item[5]);
            Nume = item[6];
            Memorie = float.Parse(item[7]);
            TipMemorie = item[8];
            Slot = item[9];
            DirectX = int.Parse(item[10]);
        }

        public void show(Label l)
        {
            l.Text = Manufacturer + " " + Nume + " " + Series + "<br/>Price: " + Price + " £<br/>Warranty " + Warranty + " months<br/>Memory: " + Memorie + "MB, " + TipMemorie + "<br/>Slot: " + Slot + "<br/>DirectX version: " + DirectX + "<br/><br/>";
        }

        public bool compatibilitate(Motherboard placa)
        {
            if (placa.SlotVideo == Slot)
                return true;
            return false;
        }

        public int Compare(PlacaVideo p)
        {
            if (Memorie > p.Memorie)
                return 1;
            else if (Memorie < p.Memorie)
                return 2;
            else
            {
                if (DirectX > p.DirectX)
                    return 1;
                else return 2;
            }
        }
    };

    public class DVDPlayer : Hardware//COD 7-
    {
        private float vitezaCitire;
        public float VitezaCitire
        {
            get { return vitezaCitire; }
            set { vitezaCitire = value; }
        }
        private float vitezaScriere;
        public float VitezaScriere
        {
            get { return vitezaScriere; }
            set { vitezaScriere = value; }
        }

        public DVDPlayer()
        { }
        public DVDPlayer(string[] item)
        {
            ID = int.Parse(item[0]);
            Manufacturer = item[1];
            Series = item[2];
            Price = float.Parse(item[3]);
            Stock = int.Parse(item[4]);
            Warranty = int.Parse(item[5]);
            VitezaCitire = float.Parse(item[6]);
            VitezaScriere = float.Parse(item[7]);
        }

        public void show(Label l)
        {
            l.Text = Manufacturer + " " + Series + "<br/>Price: " + Price + " £<br/>Warranty " + Warranty + " months<br/>Input speed: " + VitezaCitire + "kB/sec<br/>Output speed: " + VitezaScriere + "kB/sec<br/><br/>";
        }
        public int Compare(DVDPlayer p)
        {
            if (VitezaCitire > p.VitezaCitire)
                return 1;
            else if (VitezaCitire < p.VitezaCitire) return 2;

            return 0;
        }
    }

    public class Stocare : Hardware//COD 8-
    {
        private string tip;
        public string Tip
        {
            get { return tip; }
            set { tip = value; }
        }
        private int capacitate;
        public int Capacitate
        {
            get { return capacitate; }
            set { capacitate = value; }
        }
        private float vitezaTransfer;
        public float VitezaTransfer
        {
            get { return vitezaTransfer; }
            set { vitezaTransfer = value; }
        }

        public Stocare()
        { }
        public Stocare(string[] item)
        {
            ID = int.Parse(item[0]);
            Manufacturer = item[1];
            Series = item[2];
            Price = float.Parse(item[3]);
            Stock = int.Parse(item[4]);
            Warranty = int.Parse(item[5]);
            Tip = item[6];
            Capacitate = int.Parse(item[7]);
            VitezaTransfer = float.Parse(item[8]);
        }

        public void show(Label l)
        {
            l.Text = Manufacturer + " " + Series + " " + Tip + "<br/>Price: " + Price + " £<br/>Warranty " + Warranty + " months<br/>Size:" + Capacitate + "GB<br/>Speed: " + VitezaTransfer + "<br/><br/>";
        }

        public int Compare(Stocare p)
        {
            if (Capacitate > p.Capacitate)
                return 1;
            else if (Capacitate < p.Capacitate) return 2;

            return 0;
        }
    }


}
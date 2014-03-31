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
        public int ID
        { get; set; }
        public string Manufacturer
        { get; set; }
        public string Series
        { get; set; }
        public float Price
        { get; set; }
        public int Stock
        { get; set; }
        public int Warranty
        { get; set; }

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
            l.Text = Manufacturer + " " + Series + "<br/>";
        }

        public void displayPrice(Label l)
        {
            l.Text += "Warranty: " + Warranty + " months<br/><br/><b>Price: " + Price / 5.2f + " £</b><br/><br/><br/><br/>";
        }

    };


    public class HardwareException : Exception
    {
        public HardwareException()
        { }

        public HardwareException(string message) : base(message)
        { }
    }



    public class Processor : Hardware //COD 1-
    {
        public float Frequency
        { get; set; }
        public string Socket
        { get; set; }
        public int Cores
        { get; set; }

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
            Frequency = float.Parse(item[6]);
            Socket = item[7];
            Cores = int.Parse(item[8]);
        }

        public void show(Label l)
        {
            l.Text = "";
            display(l);
            l.Text += Cores + " cores, " + Frequency + "MHz<br/>Socket: " + Socket +"<br/>";
            displayPrice(l);
        }

        public bool compatibility(Motherboard mother)
        {
            if (mother.SocketCPU == Socket)
                return true;
            return false;
        }

         public int compareTo(Object m)
        {
            if (m is Processor)
            {
                Processor c = (Processor)m;
                float b = c.Frequency * c.Cores / c.Price;
                float a = Frequency * Cores / Price;
                if (a < b)
                    return -1;
                else if (a > b) return 1;
                else return 0;
            }
            else throw new HardwareException("Illegal Comparison");
        }
    };


    public class Motherboard : Hardware //COD 2-
    {
        public string SocketCPU
        { get; set; }
        public string SocketGPU
        { get; set; }
        public string SupportedMemory
        { get; set; }
        public int MemorySlots
        { get; set; }
        public int PorturiUSB
        { get; set; }
        public bool VideoIntegrat
        { get; set; }
        public bool AudioIntegrat
        { get; set; }
        public bool LANIntegrat
        { get; set; }

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
            
            SocketCPU = item[6];
            SocketGPU = item[7];
            SupportedMemory = item[8];
            MemorySlots = int.Parse(item[9]);
            PorturiUSB = int.Parse(item[10]);
            VideoIntegrat = bool.Parse(item[11]);
            AudioIntegrat = bool.Parse(item[12]);
            LANIntegrat = bool.Parse(item[13]);
        }

        public void show(Label l)
        {
            l.Text = "";
            display(l);
            l.Text += "Socket: " + SocketCPU + "<br/>" + "GPU Slot: " + SocketGPU + "<br/>RAM: " + MemorySlots + " slots, " + SupportedMemory + "<br/>" + PorturiUSB + " USB ports<br/><br/>";
            displayPrice(l);
        }

        public int compareTo(Object m)
        {
            if (m is Motherboard)
            {
                Motherboard c = (Motherboard)m;
                float b = c.MemorySlots * c.PorturiUSB / c.Price; //object to Compare with
                float a = MemorySlots * PorturiUSB / Price;       //this
                if (a < b)
                    return -1;
                else if (a > b) return 1;
                else return 0;
            }
            else throw new HardwareException("Illegal Comparison");
        }
        
    };

    public class SoundCard : Hardware //COD 3-
    {
        public int Resolution
        { get; set; }

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
            Resolution = int.Parse(item[6]);
        }

        public void show(Label l)
        {
            l.Text = "";
            display(l);
            l.Text += "Audio Resolution: " + Resolution + "<br/>";
            displayPrice(l);
        }

        public int compareTo(Object m)
        {
            if (m is SoundCard)
            {
                SoundCard c = (SoundCard)m;
                float b = c.Resolution / c.Price; 
                float a = Resolution / Price;
                if (a < b)
                    return -1;
                else if (a > b) return 1;
                else return 0;
            }
            else throw new HardwareException("Illegal Comparison");
        }
    }

    public class PowerSupplyUnit : Hardware//COD 4-
    {
        public float Power
        { get; set; }
        public int NoOfFans
        { get; set; }

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
            Power = float.Parse(item[6]);
            NoOfFans = int.Parse(item[7]);
        }

        public void show(Label l)
        {
            l.Text = "";
            display(l);
            l.Text += "Power: " + Power + "<br/>";
            displayPrice(l);
        }

        public int compareTo(Object m)
        {
            if (m is PowerSupplyUnit)
            {
                PowerSupplyUnit c = (PowerSupplyUnit)m;
                float b = c.Power * c.NoOfFans / c.Price;
                float a = Power * NoOfFans / Price;
                if (a < b)
                    return -1;
                else if (a > b) return 1;
                else return 0;
            }
            else throw new HardwareException("Illegal Comparison");
        }

    };

    public class RAM : Hardware//COD 5-
    {
        public float Memory
        { get; set; }
        public string MemoryType
        { get; set; }
        public int MemoryFrequency
        { get; set; }

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
            Memory = float.Parse(item[6]);
            MemoryFrequency = int.Parse(item[7]);
            MemoryType = item[8];
        }

        public void show(Label l)
        {
            l.Text = "";
            display(l);
            l.Text += "Memory: " + Memory + "MB " + MemoryType + "<br/>";
            displayPrice(l);
        }

        public int compareTo(Object m)
        {
            if (m is RAM)
            {
                RAM c = (RAM)m;
                float b = c.Memory * c.MemoryFrequency / c.Price;
                float a = Memory * MemoryFrequency / Price;
                if (a < b)
                    return -1;
                else if (a > b) return 1;
                else return 0;
            }
            else throw new HardwareException("Illegal Comparison");
        }

        public bool compatibility(Motherboard mother)
        {
            if (mother.SupportedMemory == MemoryType)
                return true;
            return false;
        }

    };

    public class GraphicsCard : Hardware//COD 6-
    {
        public string Chipset
        { get; set; }
        public float Memory
        { get; set; }
        public string MemoryType
        { get; set; }
        public string Slot
        { get; set; }
        public int DirectX
        { get; set; }


        public GraphicsCard()
        { }
        public GraphicsCard(string[] item)
        {
            ID = int.Parse(item[0]);
            Manufacturer = item[1];
            Series = item[2];
            Price = float.Parse(item[3]);
            Stock = int.Parse(item[4]);
            Warranty = int.Parse(item[5]);
            Chipset = item[6];
            Memory = float.Parse(item[7]);
            MemoryType = item[8];
            Slot = item[9];
            DirectX = int.Parse(item[10]);
        }

        public void show(Label l)
        {
            l.Text = "";
            display(l);
            l.Text += "Chipset: " + Chipset + "<br/>Memory: " + Memory + "MB " + MemoryType + "<br/>Slot: " + Slot + "<br/>DirectX version: " + DirectX + "<br/><br/>";
            displayPrice(l);
        }

        public int compareTo(Object m)
        {
            if (m is GraphicsCard)
            {
                GraphicsCard c = (GraphicsCard)m;
                float b = c.Memory * c.DirectX / c.Price;
                float a = Memory * DirectX / Price;
                if (a < b)
                    return -1;
                else if (a > b) return 1;
                else return 0;
            }
            else throw new HardwareException("Illegal Comparison");
        }
        
        public bool compatibility(Motherboard mother)
        {
            if (mother.SocketGPU == Slot)
                return true;
            return false;
        }

    };

    public class Storage : Hardware//COD 8-
    {
        public string Type
        { get; set; }
        public int Size
        { get; set; }
        public float Speed
        { get; set; }

        public Storage()
        { }
        public Storage(string[] item)
        {
            ID = int.Parse(item[0]);
            Manufacturer = item[1];
            Series = item[2];
            Price = float.Parse(item[3]);
            Stock = int.Parse(item[4]);
            Warranty = int.Parse(item[5]);
            Type = item[6];
            Size = int.Parse(item[7]);
            Speed = float.Parse(item[8]);
        }

        public void show(Label l)
        {
            l.Text = "";
            display(l);
            l.Text += "Type: " + Type + "<br/>Size:" + Size + "GB<br/>Speed: " + Speed + "<br/><br/>";
            displayPrice(l);
        }

        public int compareTo(Object m)
        {
            if (m is Storage)
            {
                Storage c = (Storage)m;
                float b = c.Size * c.Speed / c.Price;
                float a = Size * Speed / Price;
                if (a < b)
                    return -1;
                else if (a > b) return 1;
                else return 0;
            }
            else throw new HardwareException("Illegal Comparison");
        }

    };

}
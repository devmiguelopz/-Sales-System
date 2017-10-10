using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CapaTransversal
{
    public class ManejadorErrores
    {
        private static readonly ManejadorErrores _instancia = new ManejadorErrores();
        public static ManejadorErrores Instancia
        {
            get { return ManejadorErrores._instancia; }
        }
        public List<Errores> Error { get; set; }
        public ManejadorErrores()
        {
            this.Error = new List<Errores>();
        }
        public class Errores
        {

            public Exception Error { get; set; }
            public String MensajeCliente { get; set; }
            public String FechaHora { get; set; }


            public Errores()
            {

            }
            public Errores(Exception exepcionerror, String mensaje, String fechahora)
            {
                this.Error = exepcionerror;
                this.MensajeCliente = mensaje;
                this.FechaHora = fechahora;

            }

        }
        public void RegistrarLogs(ManejadorErrores ManejoErrores)
        {
            if (ManejoErrores.Error.Count > 0)
            {
                if (!Directory.Exists(@"C:\Log"))
                {
                    Directory.CreateDirectory(@"C:\Log");
                    if (File.Exists(@"C:\Log\LogError.txt"))
                    {
                        using (StreamWriter file = new StreamWriter(@"C:\Log\LogError.txt", true))
                        {
                            foreach (Errores Error in ManejoErrores.Error)
                            {
                                file.WriteLine(Error.Error + " // " + Error.FechaHora);
                            }
                        }
                    }
                    else
                    {
                        using (StreamWriter file = new StreamWriter(@"C:\Log\LogError.txt"))
                        {
                            foreach (Errores Error in ManejoErrores.Error)
                            {
                                file.WriteLine(Error.Error + " // " + Error.FechaHora);
                            }
                        }
                    }

                }
                else if (File.Exists(@"C:\Log\LogError.txt"))
                {
                    using (StreamWriter file = new StreamWriter(@"C:\Log\LogError.txt", true))
                    {
                        foreach (Errores Error in ManejoErrores.Error)
                        {
                            file.WriteLine(Error.Error + " // " + Error.FechaHora);
                        }
                    }
                }
                else
                {
                    using (StreamWriter file = new StreamWriter(@"C:\Log\LogError.txt"))
                    {
                        foreach (Errores Error in ManejoErrores.Error)
                        {
                            file.WriteLine(Error.Error + " // " + Error.FechaHora);
                        }
                    }
                }
            }
            else
            {
                return;
            }
        }
        public void RegistrarLogs(Exception Error, String FechaHora)
        {
            if (!Directory.Exists(@"C:\Log"))
            {
                Directory.CreateDirectory(@"C:\Log");
                if (File.Exists(@"C:\Log\LogError.txt"))
                {
                    using (StreamWriter file = new StreamWriter(@"C:\Log\LogError.txt", true))
                    {

                        file.WriteLine(Error + " // " + FechaHora);
                    }
                }
                else
                {
                    using (StreamWriter file = new StreamWriter(@"C:\Log\LogError.txt"))
                    {
                        file.WriteLine(Error + " // " + FechaHora);
                    }
                }
            }
            else if (File.Exists(@"C:\Log\LogError.txt"))
            {
                using (StreamWriter file = new StreamWriter(@"C:\Log\LogError.txt", true))
                {

                    file.WriteLine(Error + " // " + FechaHora);
                }
            }
            else
            {
                using (StreamWriter file = new StreamWriter(@"C:\Log\LogError.txt"))
                {
                    file.WriteLine(Error + " // " + FechaHora);
                }
            }
        }
    }
}

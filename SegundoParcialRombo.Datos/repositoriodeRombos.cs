using SegundoParcialRombo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcialRombo.Datos
{
    public class repositoriodeRombos
    {
        private string? nombreArchivo = "ROMBOS.txt";
        private string? rutaProyecto = Environment.CurrentDirectory;
        private string? rutaCompletaArchivo;
        public List<Rombo>? rombos;
        public repositoriodeRombos() 
        {
            rombos = leerdatos(); 
        }

        private List<Rombo>? leerdatos()
        {
            var listaRombos = new List<Rombo>();
            rutaCompletaArchivo = Path.Combine(rutaProyecto, nombreArchivo);
            if (!File.Exists(rutaCompletaArchivo))
            {
                return listaRombos;
            }
            using (var lector = new StreamReader(rutaCompletaArchivo))
            {
                while (!lector.EndOfStream)
                {
                    string? linea = lector.ReadLine();
                    Rombo? elipse = ConstruirRombos(linea);
                    listaRombos.Add(elipse!);
                }
            }
            return listaRombos;
        }

        private Rombo? ConstruirRombos(string? linea)
        {
            var guardar = linea!.Split(","); 
            var dM = int.Parse(guardar[0]);
            var dm = int.Parse(guardar[1]);
            var contorno = (contorno)int.Parse(guardar[2]);
            return new Rombo
            {
                diagonalmayor = dM,
                diagonalmenor = dm,
                contornodelrombo = contorno

            };
            
        }
        public void agregar(Rombo rombo)
        {
            rombos!.Add(rombo);
        }
        public int getcantidad()
        {
            return rombos!.Count;
        }
        public void Borrar(Rombo rombo)
        {
            rombos!.Remove(rombo);
        }
        public List<Rombo> GetRombos()
        {
            return new List<Rombo>(rombos);
        }

        public void guardardatos()
        {
            rutaCompletaArchivo = Path.Combine(rutaProyecto, nombreArchivo);
            using (var escritor = new StreamWriter(rutaCompletaArchivo))
            {
                foreach (var romboss in rombos)
                {
                    string linea = ConstruirLinea(romboss);
                    escritor.WriteLine(linea);
                }
            }
        }

        private string ConstruirLinea(Rombo romboss)
        {
            return $"{romboss.diagonalmayor},{romboss.diagonalmenor},{romboss.contornodelrombo.GetHashCode()}";
        }
    }
}

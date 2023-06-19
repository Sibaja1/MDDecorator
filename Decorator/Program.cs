using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    // Componente: Interfaz para la bebida
    public interface IBebida
    {
        string ObtenerDescripcion();
        double ObtenerPrecio();
    }

    // ComponenteConcreto: Implementación de una bebida
    public class Cafe : IBebida
    {
        public string ObtenerDescripcion()
        {
            return "Café";
        }

        public double ObtenerPrecio()
        {
            return 2.5;
        }
    }

    // Decorador: Clase base abstracta para decoradores
    public abstract class DecoradorBebida : IBebida
    {
        protected IBebida _bebida;

        public DecoradorBebida(IBebida bebida)
        {
            _bebida = bebida;
        }

        public virtual string ObtenerDescripcion()
        {
            return _bebida.ObtenerDescripcion();
        }

        public virtual double ObtenerPrecio()
        {
            return _bebida.ObtenerPrecio();
        }
    }

    // DecoradorConcreto: Decorador para agregar leche
    public class LecheDecorator : DecoradorBebida
    {
        public LecheDecorator(IBebida bebida) : base(bebida)
        {
        }

        public override string ObtenerDescripcion()
        {
            return base.ObtenerDescripcion() + ", Leche";
        }

        public override double ObtenerPrecio()
        {
            return base.ObtenerPrecio() + 0.5;
        }
    }

    // DecoradorConcreto: Decorador para agregar azúcar
    public class AzucarDecorator : DecoradorBebida
    {
        public AzucarDecorator(IBebida bebida) : base(bebida)
        {
        }

        public override string ObtenerDescripcion()
        {
            return base.ObtenerDescripcion() + ", Azúcar";
        }

        public override double ObtenerPrecio()
        {
            return base.ObtenerPrecio() + 0.25;
        }
    }

    // Uso del patrón Decorator
    public class Program
    {
        public static void Main(string[] args)
        {
            // Creamos una bebida base
            IBebida cafe = new Cafe();

            // Agregamos decoradores para personalizar la bebida
            cafe = new LecheDecorator(cafe);
            cafe = new AzucarDecorator(cafe);

            // Mostramos la descripción y el precio de la bebida
            Console.WriteLine(cafe.ObtenerDescripcion());
            Console.WriteLine("Precio: $" + cafe.ObtenerPrecio());
            Console.ReadLine();
        }
    }

}

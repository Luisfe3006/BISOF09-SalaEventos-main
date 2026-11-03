namespace SalaEventos;

// Patrón Strategy: cada tipo de cliente sabe aplicar su propio descuento
// (paso 3 del cálculo del precio). GestorReservas solo usa la interfaz.
public interface IDescuentoCliente
{
    decimal Aplicar(decimal subtotal, Sala sala, DateTime fecha, int horas);
}

// Regular: ningún descuento.
public class DescuentoRegular : IDescuentoCliente
{
    public decimal Aplicar(decimal subtotal, Sala sala, DateTime fecha, int horas)
    {
        return subtotal;
    }
}

// Corporativo: 12 %. Si además son 8 horas o más y la sala tiene capacidad
// de 100 o más, un 3 % adicional.
public class DescuentoCorporativo : IDescuentoCliente
{
    public decimal Aplicar(decimal subtotal, Sala sala, DateTime fecha, int horas)
    {
        subtotal = subtotal - (subtotal * 0.12m);
        if (horas >= 8 && sala.Capacidad >= 100)
        {
            subtotal = subtotal - (subtotal * 0.03m);
        }
        return subtotal;
    }
}

// Estudiantil: 20 % solo de lunes a viernes, en salas de capacidad 30 o menos
// y en reservas de 4 horas o más.
public class DescuentoEstudiantil : IDescuentoCliente
{
    public decimal Aplicar(decimal subtotal, Sala sala, DateTime fecha, int horas)
    {
        if (horas < 4) { return subtotal; }

        bool esFinDeSemana = fecha.DayOfWeek == DayOfWeek.Saturday || fecha.DayOfWeek == DayOfWeek.Sunday;
        if (!esFinDeSemana && sala.Capacidad <= 30)
        {
            subtotal = subtotal - (subtotal * 0.20m);
        }
        return subtotal;
    }
}

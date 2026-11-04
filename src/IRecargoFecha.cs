public interface IRecargoFecha
{
    // ¿Qué recibe?
    // Recibe la fecha en la que se calculará el recargo.
    // ¿Qué devuelve?
    // Devuelve el porcentaje de recargo de esa fecha.
    // ¿Qué garantiza?
    // Calcula el recargo según la regla implementada.
    // ¿Qué promete NO hacer?   
    // No modifica la fecha ni calcula el total de la reserva.
    public decimal CalcularRecargo(DateTime fecha);
}

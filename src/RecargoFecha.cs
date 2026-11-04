public class RecargoFinDeSemana : IRecargoFecha
{
    public decimal CalcularRecargo(DateTime fecha)
    {
        decimal recargoFinDeSemana = 0m;

        if (fecha.DayOfWeek == DayOfWeek.Saturday || fecha.DayOfWeek == DayOfWeek.Sunday)
        {
            recargoFinDeSemana = 0.25m;
        }

        decimal recargoTemporada = new RecargoTemporada().CalcularRecargo(fecha);
        return recargoFinDeSemana + recargoTemporada;
    }
}

public class RecargoFestivo : IRecargoFecha
{
    private readonly List<DateTime> _festivos;

    public RecargoFestivo(List<DateTime> festivos)
    {
        _festivos = festivos;
    }

    public decimal CalcularRecargo(DateTime fecha)
    {
        return _festivos.Contains(fecha.Date) ? 0.40m : 0m;
    }
}

public class RecargoTemporada : IRecargoFecha
{
    public decimal CalcularRecargo(DateTime fecha)
    {
        return fecha.Month == 12 ? 0.10m : 0m;
    }
}
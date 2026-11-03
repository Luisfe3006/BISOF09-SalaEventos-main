# Diagrama de clases: Strategy para el descuento por tipo de cliente

- **GestorReservas** es el contexto: guarda las estrategias (agregación, rombo) y usa la interfaz sin preguntar el tipo de cliente con `if`.
- **IDescuentoCliente** es la interfaz de la estrategia.
- **DescuentoRegular**, **DescuentoCorporativo** y **DescuentoEstudiantil** son las estrategias concretas (realización, triángulo con línea punteada).
- **Program** arma las estrategias y se las pasa a GestorReservas.

![Diagrama de clases](diagrama-clases.png)

```mermaid
classDiagram
    direction TB
    class Program {
        +Main(args) void
    }
    class GestorReservas {
        -Dictionary~string, IDescuentoCliente~ descuentos
        +GestorReservas(descuentos)
        +CrearReserva(...) string
        -ObtenerDescuento(tipo) IDescuentoCliente
    }
    class IDescuentoCliente {
        <<interface>>
        +Aplicar(subtotal, sala, fecha, horas) decimal
    }
    class DescuentoRegular {
        +Aplicar(subtotal, sala, fecha, horas) decimal
    }
    class DescuentoCorporativo {
        +Aplicar(subtotal, sala, fecha, horas) decimal
    }
    class DescuentoEstudiantil {
        +Aplicar(subtotal, sala, fecha, horas) decimal
    }
    Program ..> GestorReservas : crea y le pasa las estrategias
    GestorReservas o-- IDescuentoCliente : descuentos
    IDescuentoCliente <|.. DescuentoRegular
    IDescuentoCliente <|.. DescuentoCorporativo
    IDescuentoCliente <|.. DescuentoEstudiantil
```

using System.Globalization;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
var cultura = new CultureInfo("es-CO"); 


string especieMascota = "perro";   
int edadMascota = 7;               
double peso = 28.5;                
bool tieneVacunasAlDia = false;
bool esSocio = true;
string motivoConsulta = "cirugia"; 


string etapaVida = edadMascota switch
{
    < 1              => "Cachorro",
    >= 1 and <= 3    => "Joven",
    >= 4 and <= 8    => "Adulto",
    _                => "Senior"
};


string alertaVacuna;
if ((especieMascota == "perro" || especieMascota == "gato") && !tieneVacunasAlDia)
{
    alertaVacuna = "ALERTA: vacunación urgente requerida";
}
else if ((especieMascota == "perro" || especieMascota == "gato") && tieneVacunasAlDia)
{
    alertaVacuna = "Vacunación al día";
}
else
{
    alertaVacuna = "Esquema de vacunación no aplica";
}


decimal costoBase;
switch (motivoConsulta)
{
    case "vacuna":
        costoBase = 35000;
        break;
    case "revision":
        costoBase = 50000;
        break;
    case "cirugia":
        costoBase = 280000;
        break;
    case "urgencia":
        costoBase = 150000;
        break;
    default:
        costoBase = 0;
        break;
}


double porcentajeDescuento = esSocio
    ? (peso > 25 ? 15.0 : 10.0)
    : 0.0;

decimal descuento = costoBase * (decimal)(porcentajeDescuento / 100);
decimal costoFinal = costoBase - descuento;


string recomendacion;
if (motivoConsulta == "cirugia")
{
    if (etapaVida == "Senior")
    {
        recomendacion = "Reposo absoluto por 10 días, control post-operatorio obligatorio";
    }
    else
    {
        recomendacion = "Reposo por 5 días, evitar ejercicio intenso";
    }
}
else if (motivoConsulta == "urgencia")
{
    if (!tieneVacunasAlDia)
    {
        recomendacion = "Atender urgencia y programar vacunación inmediata";
    }
    else
    {
        recomendacion = "Seguimiento en 48 horas";
    }
}
else
{
    recomendacion = "Seguimiento en próxima consulta de rutina";
}


Console.WriteLine("=== Reporte de Atención Veterinaria ===");
Console.WriteLine($"Mascota: {especieMascota} | Edad: {edadMascota} años | Etapa: {etapaVida}");
Console.WriteLine($"Estado de vacunación: {alertaVacuna}");
Console.WriteLine($"Motivo: {motivoConsulta} | Costo base: {costoBase.ToString("C0", cultura)}");
Console.WriteLine($"Descuento: {porcentajeDescuento}% | Costo final: {costoFinal.ToString("C0", cultura)}");
Console.WriteLine($"Recomendación: {recomendacion}");

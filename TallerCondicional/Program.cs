Console.WriteLine("Ingresa un número entero:");
int numero = int.Parse(Console.ReadLine() ?? "0");

Console.WriteLine(CheckNumber(numero));

static string CheckNumber(int numero)
{
    if (numero > 0)
    {
        return "El número es positivo";
    }
    else if (numero < 0)
    {
        return "El número es negativo";
    }
    else
    {
        return "El número es cero";
    }
}

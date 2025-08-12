//Aplicando a função do C# que ordena

public class Vetor
{
    public static void Main(string[] args)
    {
        int tamanho = 100;
        int[] numeros = new int[tamanho];

        Random random = new Random();

        for (int i = 0; i < tamanho; i++)
        {
            numeros[i] = random.Next(999);
        }

        Console.WriteLine(" Iniciais: ");
        for (int i = 0; i < tamanho; i++)
        {
            Console.Write(numeros[i] + " ");
        }
        Console.WriteLine(" ");

        //Função do C# que faz a ordenação :)
        Array.Sort(numeros);

        Console.WriteLine("Ordenados:");
            for (int i = 0; i < tamanho; i++)
            {
                Console.Write(numeros[i] + " ");
            }

            Console.WriteLine(" ");
        }
    }





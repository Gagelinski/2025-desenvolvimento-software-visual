//Passos para resolver bubblesort
//1 - Criar um array (vetor) de 100 posições
//2 - Criar um laço de repetição para percorer o array (vetor)
//3 - Preencher cada posição com um valor aleatório
//4 - Imprimir o array (vetor) com os valores aleatórios

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

        //5 - Percorrer o vetor com valores aleatórios
        //6 - Comparara a posição atual com a próxima posição
        //7 - Se a posição atual for maior que a próxima, trocar as posições
        //8 - Imprimir o vetor com os valores ordenados
        // 9 - Percorrer o vetor com valores aleatórios novamente

        //se i for maior que i+1, i+1 vai pra temporária e i vai pra i+1 e a temporária vai pra i
        int temp;
        bool troca = false;

        do
        {
            troca = false;
            for (int i = 0; i < tamanho - 1; i++)
            {
                if (numeros[i] > numeros[i + 1])
                {
                    temp = numeros[i + 1];
                    numeros[i + 1] = numeros[i];
                    numeros[i] = temp;
                    troca = true;
                }
            }
        } while (troca); 
        



        Console.WriteLine("Ordenados:");
            for (int i = 0; i < tamanho; i++)
            {
                Console.Write(numeros[i] + " ");
            }

            Console.WriteLine(" ");
        }
    }




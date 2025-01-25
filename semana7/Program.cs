using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Número de discos 
        int numDiscos = 3; 
        TorresHanoi(numDiscos); 
    }

    static void TorresHanoi(int numDiscos)
    {
        //creamos tres pilas 
        Stack<int> torreA = new Stack<int>();
        Stack<int> torreB = new Stack<int>();
        Stack<int> torreC = new Stack<int>();

        // Inicializamos la torre A con los discos
        for (int i = numDiscos; i >= 1; i--)
        {
            torreA.Push(i); // Se añaden los discos al stack de la torre A
        }

        // Mostramos como estan las pilas al inicio 
        Console.WriteLine("Estado inicial:");
        MostrarTorres(torreA, torreB, torreC);

      
        MoverDiscos(numDiscos, torreA, torreC, torreB);

    
        Console.WriteLine("\nEstado final:");
        MostrarTorres(torreA, torreB, torreC);
    }

    static void MoverDiscos(int numDiscos, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar)
    {
        // la regla es que existan discos 
        if (numDiscos > 0)
        {
            // Movemos lo discos(menos 1) desde la torre origen a la torre auxiliar
            MoverDiscos(numDiscos - 1, origen, auxiliar, destino);

            //Mover el disco más grande de la torre origen a la torre destino
            int disco = origen.Pop(); // Sacar el disco de su torre
            destino.Push(disco); // Poner el disco en la torre destino

            // Mostramos lo que ha pasado
            Console.WriteLine($"\nMover disco {disco} de {ObtenerNombreTorre(origen)} a {ObtenerNombreTorre(destino)}");
            MostrarTorres(origen, auxiliar, destino);

            //Movemos los discos(menos 1) desde la torre auxiliar a la torre destino
            MoverDiscos(numDiscos - 1, auxiliar, destino, origen);
        }
    }

    static void MostrarTorres(Stack<int> torreA, Stack<int> torreB, Stack<int> torreC)
    {
        // Mostrar los discos que tiene cada torre
        Console.WriteLine("Torre A: " + string.Join(", ", torreA));
        Console.WriteLine("Torre B: " + string.Join(", ", torreB));
        Console.WriteLine("Torre C: " + string.Join(", ", torreC));
    }

    static string ObtenerNombreTorre(Stack<int> torre)
    {
        // Identificar el nombre de la torre según el contenido
        if (torre.Count == 0)
            return "Torre Desconocida"; // es en caso de que este vacia 

        if (torre.Contains(1))
            return "Torre A"; // La torre que contiene el disco 1 se llama Torre A
        else if (torre.Contains(2))
            return "Torre B"; // La torre que contiene el disco 2 se llama Torre B
        else
            return "Torre C"; // La ultima es la torre C
    }
}

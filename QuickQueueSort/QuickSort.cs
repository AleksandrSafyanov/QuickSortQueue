using System;
using System.Collections.Generic;

namespace QuickQueueSort
{
  class Sort : Queue<int>
  {
    public ulong N_op { get; set; } = 0;
    //получение значения элемента по его индексу в очереди
    public int GetNumber(int Position)
    {
      N_op++;
      if (Count != 0)
      {
        N_op++;
        int ValueGet = 0;

        N_op++;
        int Count1 = Count + 1;

        N_op += 2;
        //переборка всех значений очереди
        for (int i = 1; i < Count1; i++)
        {
          N_op += 2 + 1;
          //если цикл дошел до нужной позиции => в ValueGet записывается значение
          if (i == Position)
          {
            N_op += 2;
            ValueGet = Peek();
          }

          N_op++;
          //если позиция не равна единице =>  тогда 1ый элемент отправляем в конец  очереди
          if (Position != 1)
          {
            N_op += 2;
            Enqueue(Dequeue());
          }
          //иначе цикл прекращается
          else
            break;
        }
        return ValueGet;
      }
      else
      {
        Console.WriteLine("Queue is Empty!");
        return 0;
      }
    }

    //установка значения по индексу
    public void SetNumber(int Position, int ValueSet)
    {
      N_op += 2;
      if (Count != 0)
      {
        N_op++;
        int Count1 = Count + 1;

        N_op += 2;
        //переборка всех значений очереди
        for (int i = 1; i < Count1; i++)
        {
          N_op += 2 + 1;
          //если цикл дошел до нужной позиции => "голова" удаляется и в "хвост" записывается значение передаваемое параметром
          if (i == Position)
          {
            N_op += 2;
            Dequeue();
            Enqueue(ValueSet);
          }
          //иначе 1 элемент будет отправляться в конец
          else
          {
            N_op += 2;
            Enqueue(Dequeue());
          }
        }
      }
      else
      {
        Console.WriteLine("Queue is Empty!");
        return;
      }    
    }

    //быстрая сортировка
    public void QuickSort(int leftBorder, int rightBorder)
    {
      N_op++;
      if (leftBorder > rightBorder)
        return;

      N_op += 2;
      int left = leftBorder;
      int right = rightBorder;
      N_op += 1;
      int pivot = GetNumber(leftBorder);

      N_op++;
      while (left <= right)
      {
        N_op++;
        while (GetNumber(left) < pivot)
        {
          N_op++;
          left++;
        }

        N_op++;
        while (GetNumber(right) > pivot)
        {
          N_op++;
          right--;
        }
        N_op++;
        if (left <= right)
        {
          Swap(left, right);
          N_op += 2;
          left++;
          right--;
        }
      }
      N_op++;
      if (left < rightBorder)
        QuickSort(left, rightBorder);

      N_op++;
      if (leftBorder < right)  
        QuickSort(leftBorder, right); 
    }

      /*
      N_op++;
      while (left != right)
      {

        N_op++;
        while (left != right)
        {
          N_op++;
          if (GetNumber(left) <= GetNumber(right))
          {
            N_op += 2;
            --right;
          }

          else
          {
            Swap(left, right);
            N_op += 2;
            --right;
            break;
          }
        }

        N_op++;
        while (left != right)
        {
          N_op++;
          if (GetNumber(left) <= GetNumber(right))
          {
            N_op += 2;
            ++left;
          }

          else
          {
            Swap(left, right);
            N_op += 2;
            ++left;
            break;
          }
        }
      }
      N_op += 2;
      if (left - 1 > leftBorder)  //2
      {
        N_op++;
        QuickSort(leftBorder, left - 1); //left - 1 => 1 операция
      }
      N_op+=2;
      if (right + 1 < rightBorder)
      {
        N_op++;
        QuickSort(right + 1, rightBorder);
      }
      */
    //}

    //метод замены элементов местами
    public void Swap(int leftElement, int rightElement)
    {
      N_op++;
      int temp = GetNumber(leftElement);
      SetNumber(leftElement, GetNumber(rightElement));
      SetNumber(rightElement, temp);
    }
  }
}

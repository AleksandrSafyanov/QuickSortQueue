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

        N_op += 3;
        //переборка всех значений очереди
        for (int i = 1; i < Count + 1; i++)
        {
          N_op += 3 + 1;
          //если цикл дошел до нужной позиции => в ValueGet записывается значение
          if (i == Position)
          {
            N_op += 5;
            ValueGet = Peek();
          }

          N_op++;
          //если позиция не равна единице =>  тогда 1ый элемент отправляем в конец  очереди
          if (Position != 1)
          {
            N_op += 12 + 8;
            Enqueue(Dequeue());
          }
          //иначе цикл прекращается
          else
            break;
        }
        N_op++;
        return ValueGet;
      }
      else
      {
        Console.WriteLine("Queue is Empty!");
        N_op++;
        return 0;
      }
    }

    //установка значения по индексу
    public void SetNumber(int Position, int ValueSet)
    {
      N_op += 2;
      if (Count != 0)
      {
        N_op += 2;
        //если кол-во элементов в очереди больше переданной позиции
        if (Position <= Count)
        {
          N_op += 3;
          //переборка всех значений очереди
          for (int i = 1; i < Count + 1; i++)
          {
            N_op += 3 + 1;
            //если цикл дошел до нужной позиции => "голова" удаляется и в "хвост" записывается значение передаваемое параметром
            if (i == Position)
            {
              N_op += 20;
              Dequeue();  //8
              Enqueue(ValueSet);  //20
            }
            //иначе 1 элемент будет отправляться в конец
            else
            {
              N_op += 20;
              Enqueue(Dequeue());
            }
          }
        }
        //если кол-во элементов в очереди меньше переданной позиции 
        else
        {
          N_op += 2;
          //если переданная позиция равна кол-ву элементов в очереди + 1 => добавляется значение в начало
          if (Position == Count + 1)
          {
            N_op += 12;
            Enqueue(ValueSet);
          }
            
          //иначе все последующие элементы до переданной позиции заполнятся нулями
          else
          {
            N_op += 4;
            for (int i = Count + 1; i < Position; i++)
            {
              N_op += 4 + 12;
              Enqueue(0);
            }
            N_op += 12;
            //а на место переданной позиции установится переданной значение
            Enqueue(ValueSet);
          }
        }
      }
      else
      {
        Console.WriteLine("Queue is Empty!");
        N_op++;
        return;
      }    
    }

    //быстрая сортировка
    public void QuickSort(int leftBorder, int rightBorder)
    {
      N_op++;
      if (leftBorder >= rightBorder)
      {
        N_op++;
        return;
      }

      N_op+=2;
      int left = leftBorder;
      int right = rightBorder;

      N_op++;
      while (left != right)
      {
        N_op++;
        while (left != right)
        {
          N_op++;
          if (GetNumber(left) <= GetNumber(right))
          {
            N_op+=2;
            --right;
          }

          else
          {
            Swap(left, right);
            N_op += 2;
            --right;
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
          }
        }
      }
      N_op++;
      if (left - 1 > leftBorder)
        QuickSort(leftBorder, left - 1);

      N_op++;
      if (right + 1 < rightBorder)
        QuickSort(right + 1, rightBorder);
    }

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

using System;
using System.Collections.Generic;

namespace QuickQueueSort
{
  class Sort : Queue<int>
  {
    //получение значения элемента по его индексу в очереди
    public int GetNumber(int Position)
    {
      if (Count != 0)
      {
        int ValueGet = 0;

        //переборка всех значений очереди
        for (int i = 1; i < Count + 1; i++)
        {
          //если цикл дошел до нужной позиции => в ValueGet записывается значение
          if (i == Position)
            ValueGet = Peek();

          //если позиция не равна единице =>  тогда 1ый элемент отправляем в конец  очереди
          if (Position != 1)
            Enqueue(Dequeue());
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
      if (Count != 0)
      {
        //если кол-во элементов в очереди больше переданной позиции
        if (Position <= Count)
        {
          //переборка всех значений очереди
          for (int i = 1; i < Count + 1; i++)
          {
            //если цикл дошел до нужной позиции => "голова" удаляется и в "хвост" записывается значение передаваемое параметром

            if (i == Position)
            {
              Dequeue();
              Enqueue(ValueSet);
            }
            //иначе 1 элемент будет отправляться в конец
            else
              Enqueue(Dequeue());
          }
        }
        //если кол-во элементов в очереди меньше переданной позиции 
        else
        {
          //если переданная позиция равна кол-ву элементов в очереди + 1 => добавляется значение в начало
          if (Position == Count + 1)
            Enqueue(ValueSet);
          //иначе все последующие элементы до переданной позиции заполнятся нулями
          else
          {
            for (int i = Count + 1; i < Position; i++)
              Enqueue(0);
            //а на место переданной позиции установится переданной значение
            Enqueue(ValueSet);
          }
        }
      }
      else
        Console.WriteLine("Queue is Empty!");
    }

    //быстрая сортировка
    public void QuickSort(int leftBorder, int rightBorder)
    {
      if (leftBorder >= rightBorder)
        return;

      int left = leftBorder;
      int right = rightBorder;

      while (left != right)
      {
        while (left != right)
        {
          if (GetNumber(left) <= GetNumber(right))
            --right;

          else
          {
            Swap(left, right);
            --right;
          }
        }
        while (left != right)
        {
          if (GetNumber(left) <= GetNumber(right))
            ++left;

          else
          {
            Swap(left, right);
            ++left;
          }
        }
      }
      if (left - 1 > leftBorder)
        QuickSort(leftBorder, left - 1);

      if (right + 1 < rightBorder)
        QuickSort(right + 1, rightBorder);
    }

    //метод замены элементов местами
    public void Swap(int leftElement, int rightElement)
    {
      int temp = GetNumber(leftElement);
      SetNumber(leftElement, GetNumber(rightElement));
      SetNumber(rightElement, temp);
    }
  }
}

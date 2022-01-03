using System;
using System.Collections.Generic;
public class InfixEvaluation
{

    public int evaluate(String expression)
    {
        //Stack for Numbers
        Stack<int> numbers = new Stack<int>();

        //Stack for operators
        Stack<char> operations = new Stack<char>();
        for (int i = 0; i < expression.Length; i++)
        {
            char c = expression[i];
            //check if it is number
            if (char.IsDigit(c))
            {
                //Entry is Digit, it could be greater than one digit number
                int num = 0;
                while (char.IsDigit(c))
                {
                    num = num * 10 + (c - '0');
                    i++;
                    if (i < expression.Length)
                        c = expression[i];
                    else
                        break;
                }
                i--;
                //push it into stack
                numbers.Push(num);
            }
            else if (c == '(')
            {
                //push it to operators stack
                operations.Push(c);
            }
            //Closed brace, evaluate the entire brace
            else if (c == ')')
            {
                while (operations.Peek() != '(')
                {
                    int output = performOperation(numbers, operations);
                    //push it back to stack
                    numbers.Push(output);
                }
                operations.Pop();
            }
            // current character is operator
            else if (isOperator(c))
            {
                //1. If current operator has higher precedence than operator on top of the stack,
                //the current operator can be placed in stack
                // 2. else keep popping operator from stack and perform the operation in  numbers stack till
                //either stack is not empty or current operator has higher precedence than operator on top of the stack
                while (operations.Count > 0 && precedence(c) <= precedence(operations.Peek()))
                {
                    int output = performOperation(numbers, operations);
                    //push it back to stack
                    numbers.Push(output);
                }
                //now push the current operator to stack
                operations.Push(c);
            }
        }
        //If here means entire expression has been processed,
        //Perform the remaining operations in stack to the numbers stack

        while (operations.Count > 0)
        {
            int output = performOperation(numbers, operations);
            //push it back to stack
            numbers.Push(output);
        }
        return numbers.Pop();
    }

    static int precedence(char c)
    {
        switch (c)
        {
            case '+':
            case '-':
                return 1;
            case '*':
            case '/':
                return 2;
            case '^':
                return 3;
        }
        return -1;
    }

    public int performOperation(Stack<int> numbers, Stack<char> operations)
    {
        int a = numbers.Pop();
        int b = numbers.Pop();
        char operation = operations.Pop();
        switch (operation)
        {
            case '+':
                return a + b;
            case '-':
                return b - a;
            case '*':
                return a * b;
            case '/':
                if (a == 0)
                    throw new DivideByZeroException("Cannot divide by zero");
                return b / a;
        }
        return 0;
    }

    public bool isOperator(char c)
    {
        return (c == '+' || c == '-' || c == '/' || c == '*' || c == '^');
    }

    public static void Main(String[] args)
    {
        String infixExpression = "2*(5*(3+6))/15-2";
        InfixEvaluation i = new InfixEvaluation();
        Console.WriteLine(i.evaluate(infixExpression));
    }
}
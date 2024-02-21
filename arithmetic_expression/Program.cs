namespace arithmetic_expression
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Введите арифметическое выражение (только + и -):");
            string expression = Console.ReadLine();

            int result = CalculateExpression(expression);
            Console.WriteLine("Результат: " + result);
        }

        public static int CalculateExpression(string expression)
        {
            int result = 0;

            if (string.IsNullOrEmpty(expression))
            {
                Console.WriteLine("Выражение пусто.");
                return result;
            }

            if (!expression.Contains("+") && !expression.Contains("-"))
            {
                Console.WriteLine("Неправильный формат выражения.");
                return result;
            }

            string[] operands = expression.Split(new char[] { '+', '-' }, StringSplitOptions.RemoveEmptyEntries);
            char[] operators = expression.Where(c => c == '+' || c == '-').ToArray();

            if (operands.Length != operators.Length + 1)
            {
                Console.WriteLine("Неправильное количество операндов и операторов.");
                return result;
            }

            result = int.Parse(operands[0]);
            for (int i = 0; i < operators.Length; i++)
            {
                int operand = int.Parse(operands[i + 1]);
                if (operators[i] == '+')
                    result += operand;
                else if (operators[i] == '-')
                    result -= operand;
            }

            return result;
        }
    }
}

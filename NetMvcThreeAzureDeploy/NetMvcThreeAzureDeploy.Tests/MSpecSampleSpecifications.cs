using Machine.Specifications;

namespace NetMvcThreeAzureDeploy.Tests
{
    public class Operator
    {
        public decimal Add(decimal firstOperand, decimal secondOperand)
        {
            return firstOperand + secondOperand;
        }

        public decimal Add(params decimal[] operands)
        {
            decimal value = 0m;

            foreach (var operand in operands)
            {
                value += operand;
            }

            return value;
        }
    }

    [Subject("adding two operands")]
    public class when_adding_two_operands
    {
        static decimal value;

        Establish context = () =>
            value = 0m;

        Because of = () =>
            value = new Operator().Add(42.0m, 42.0m);

        It should_add_both_operands = () =>
            value.ShouldEqual(84.0m);
    }

    [Subject("adding multiple operands")]
    public class when_adding_multiple_operands
    {
        static decimal value;

        Establish context = () =>
            value = 0m;

        Because of = () =>
            value = new Operator().Add(42m, 42m, 42m);

        It should_add_all_operands = () =>
            value.ShouldEqual(126m);
    }
}

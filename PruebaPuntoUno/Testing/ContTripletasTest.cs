using Microsoft.VisualStudio.TestPlatform.TestHost;
using PruebaPuntoUno;
using Xunit;

namespace Testing
{
    public class ContTripletasTest
    {
        [Fact]

        public void ValidateArrays()
        {

            var arraysValidator = new PruebaPuntoUno.Program();

            int count1 = arraysValidator.ContTripletas([1, 2, 3, 4, 3]);

            Assert.Equal(0, count1);

            int count2 = arraysValidator.ContTripletas([1, 1, 1, 3, 3, 2, 2, 2]);

            Assert.Equal(2, count2);

            int count3 = arraysValidator.ContTripletas([0, 0, 5, 9, 9, 9, 3, 2]);

            Assert.Equal(1, count3);

            int count4 = arraysValidator.ContTripletas([1, 1, 1, 1, 1, 1, 1]);

            Assert.Equal(2, count4);

            int count5 = arraysValidator.ContTripletas([0, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6]);

            Assert.Equal(3, count5);
        }
    }
}

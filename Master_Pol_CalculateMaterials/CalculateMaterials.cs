using yp02.Classes.Context;
using System;
using System.Linq;

namespace Master_Pol_CalculateMaterials
{
    class CalculateMaterials
    {
        private Contexts Contexts = new Contexts();

        public int GetCalculateMaterials(int typeProductName, int idMaterials, int countProduct, double parametr_1, double parametr_2)
        {
            try
            {
                double coefficient = Contexts.Type_Product.FirstOrDefault(x => x.id == typeProductName).coefficient;
                double defectRate = Contexts.Materials.FirstOrDefault(x => x.id == idMaterials).defectRate;
                double receivedOneProduct = parametr_1 * parametr_2 * coefficient;
                double receivedNotDefect = receivedOneProduct * countProduct;
                double result = receivedNotDefect + receivedNotDefect * defectRate;
                return (int)Math.Ceiling(result);
            }
            catch { return -1; }
        }
    }
}

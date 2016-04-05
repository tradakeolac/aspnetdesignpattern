using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap8.FrontController.Model
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> FindAll();
        Category FindBy(int id);
    }
}

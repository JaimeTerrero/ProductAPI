using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VictorVentral.Products.Application.Products.GenericService
{
    public interface IMessagePublisher
    {
        Task Publish<T> (T obj);
        Task Publish(string raw);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.App.Api.LogicLayer
{
    public abstract class BaseBLL<T> where T : BaseBLL<T>, new()
    {
        private static readonly Lazy<T> instance = new Lazy<T>(() => new T());

        public static T Instance { get { return instance.Value; } }
    }
}

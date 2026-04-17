using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum Action
    {
        Pay = 0,
        Finish = 1, //após completar a compra e usou.
        Cancel = 2, // não pode concelar nada que ja esteja pago
        Refound = 3, //so pode ser reembolsado se ja tiver sido pago
        Reopen = 4 // so pode ser reaberto se tiver sido cancelado 
    }
}

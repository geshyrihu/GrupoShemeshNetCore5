using System;
using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Entities
{
    // ... Cedula presupuestal Cuentas
    public class BudgetCardDetail
    {
        public int Id { get; set; }

        [Display(Name = "Cedula presupuestal")]
        public int BudgetCardId { get; set; }
        public virtual BudgetCard BudgetCard { get; set; }

        [Display(Name = "Partida presupuestal")]
        public int ChartOfAccountsId { get; set; }
        public virtual ChartOfAccount MyProperty { get; set; }

        [Display(Name = "Presupuesto Mensual")]
        public decimal MonthlyBudget { get; set; }

        [Display(Name = "Presupuesto ejercido")]
        public decimal ExercisedBudget { get; set; }

        [Display(Name = "Presupuesto Acumulado")]
        public decimal AccumulatedBudget
        {
            get
            {
                return MonthlyBudget * Today;
            }
        }
        [Display(Name = "Saldo disponible")]
        public decimal BudgetRemaining
        {
            get
            {
                return MonthlyBudget - ExercisedBudget;
            }
        }
        [Display(Name = "Presupuesto Anual")]
        public decimal YearBudget
        {
            get
            {
                return MonthlyBudget * 12;
            }
        }

        [Display(Name = "Usuario")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        private int Today = DateTime.Today.Month;

    }
}

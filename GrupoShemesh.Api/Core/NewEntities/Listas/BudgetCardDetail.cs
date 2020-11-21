using System;
using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Entities
{
    // ... Cedula presupuestal Detalle
    public class BudgetCardDetail
    {
        public int Id { get; set; }

        [Display(Name = "Cedula presupuestal")]
        public int BudgetCardId { get; set; }
        public virtual BudgetCard BudgetCard { get; set; }

        [Display(Name = "Partida presupuestal")]
        public int ChartOfAccountsId { get; set; }
        public virtual ChartOfAccount ChartOfAccount { get; set; }

        [Display(Name = "Presupuesto Mensual")]
        public double MonthlyBudget { get; set; }

        [Display(Name = "Presupuesto ejercido")]
        public double ExercisedBudget { get; set; }

        [Display(Name = "Presupuesto Acumulado")]
        public double AccumulatedBudget
        {
            get
            {
                return MonthlyBudget * Today;
            }
        }
        [Display(Name = "Presupueto disponible")]
        public double BudgetRemaining
        {
            get
            {
                return AccumulatedBudget - ExercisedBudget;
            }
        }
        [Display(Name = "Presupuesto Anual")]
        public double YearBudget
        {
            get
            {
                return MonthlyBudget * 12;
            }
        }
        [Display(Name = "Presupuesto disponible a fin de año")]
        public double BudgetRemainingEndYear
        {
            get
            {
                return YearBudget - ExercisedBudget;
            }
        }

        [Display(Name = "Usuario")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        private readonly int Today = DateTime.Today.Month;

    }
}

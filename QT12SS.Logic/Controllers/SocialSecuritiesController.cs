using QT12SS.Logic.Entities;
using QT12SS.Logic.Modules.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QT12SS.Logic.Controllers
{
    public sealed class SocialSecuritiesController : GenericController<Logic.Entities.SocialSecurity>
    {
        public SocialSecuritiesController()
        {
        }

        public SocialSecuritiesController(ControllerObject other) : base(other)
        {
        }

        protected override async Task BeforeActionExecuteAsync(ActionType actionType, SocialSecurity entity)
        {
            if (actionType == ActionType.Update)
            {
                await ConfirmCreationDate(entity);
            }
        }

        protected void ValidateCCN(string CreditCardNumber)
        {
            if (CreditCardNumber.Length != 16)
                throw new LogicException(".");

            for (int i = 0; i < CreditCardNumber.Length; i++)
            {
                if (!char.IsDigit(CreditCardNumber[i]))
                    throw new LogicException(".");
            }
            int evenSum = 0, oddSum = 0, sum = 0, currentNum = 0, compareNum, checkNum;
            for (int i = 0; i < CreditCardNumber.Length - 1; i++)
            {
                if(i % 2 == 0)
                {
                    currentNum = (CreditCardNumber[i] - '0') * 2;
                    while(currentNum>0)
                    {
                        evenSum += currentNum % 10;
                        currentNum /= 10;
                    }
                }
                else if(i % 2 == 1)
                {
                    oddSum += CreditCardNumber[i];
                }
            }
            sum = evenSum + oddSum;
            sum %= 10;
            checkNum = 10 - sum;
            if(checkNum == 10)
                checkNum = 0;

            compareNum = CreditCardNumber[CreditCardNumber.Length - 1] - '0';

            if (checkNum != compareNum)
                throw new LogicException(".");

            
        }

        private void ValidateISBN(string isbNUMBER)
        {
            if (isbNUMBER.Length != 10)
                throw new LogicException(".");

            var checkVal = 0;

            for (int i = 1; i < isbNUMBER.Length; i++)
            {
                if (!char.IsDigit(isbNUMBER[i - 1]))
                    throw new LogicException(".");
                var temp = isbNUMBER[i] - '0';

                checkVal += temp * i;
            }
            checkVal = checkVal % 11;

            if (checkVal == 0 && (isbNUMBER[isbNUMBER.Length - 1] - '0') == 'X')
                throw new LogicException(".");

            var compareNum = isbNUMBER[isbNUMBER.Length-1] - '0';

            if (checkVal != compareNum)
                throw new LogicException(".");
        }
    
       
        public Task<SocialSecurity[]> QueryByParamsAsync(string? socNr, string? firstName, string? lastName, StateCode? state, string? note)
        {
            var result = EntitySet.AsQueryable();

            if(!string.IsNullOrEmpty(socNr))
                result = result.Where(e=>e.SocialSecurityNumber.Contains(socNr));
            if(!string.IsNullOrWhiteSpace(firstName))
                result = result.Where(e=>e.FirstName.ToUpper().Contains(firstName.ToUpper()));
            if(!string.IsNullOrWhiteSpace(lastName))
                result = result.Where(e=>e.LastName.ToUpper().Contains(lastName.ToUpper()));
            if (state != null)
                result = result.Where(e => e.State == state);
            if(!string.IsNullOrWhiteSpace(note))
                result = result.Where(e=> string.IsNullOrWhiteSpace(e.Note) ? false : e.Note.ToUpper().Contains(note.ToUpper()));

            return result.AsNoTracking().ToArrayAsync();
        }

        private async Task ConfirmCreationDate(SocialSecurity entity)
        {
            var oldEntity = await GetByIdAsync(entity.Id);

            if (oldEntity == null)
                throw new LogicException(".");

            entity.CreationDate = oldEntity.CreationDate;
        }

        protected override void ValidateEntity(ActionType actionType, SocialSecurity entity)
        {
            if(actionType == ActionType.Insert)
            {
                ValidateSocialSecurityNumber(entity.SocialSecurityNumber);
                ValidateBirthday(entity.BirthDay);
                entity.CreationDate = DateTime.UtcNow;

            }
            if(actionType == ActionType.Update)
            {
                ValidateSocialSecurityNumber(entity.SocialSecurityNumber);
                ValidateBirthday(entity.BirthDay);
            }
        }

        private void ValidateBirthday(DateTime? birthDay)
        {
            var minDate = new DateTime(1900, 1, 1);
            var maxDate = DateTime.UtcNow;

            if (birthDay > maxDate || birthDay < minDate)
                throw new LogicException(".");
        }

        private void ValidateSocialSecurityNumber(string socialSecurityNumber)
        {
            var weightArray = new int[] { 3, 7, 9, 0, 5, 8, 4, 2, 1, 6 };
            int sum = 0, checkNum;

            if (socialSecurityNumber.Length != 10)
                throw new LogicException(".");

            for (int i = 0; i < socialSecurityNumber.Length; i++)
            {
                if (!char.IsDigit(socialSecurityNumber[i]))
                    throw new LogicException(".");

                if (i == 0 && (socialSecurityNumber[i] - '0') == 0)
                    throw new LogicException(".");

                sum += weightArray[i] + socialSecurityNumber[i];
            }
            checkNum = sum % 11;
            if (checkNum == 10 || checkNum != (socialSecurityNumber[3] - '0'))
                throw new LogicException(".");


        }
    }
}

using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Core.Aspects.Transaction
{
    public class AsyncTransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    var task = invocation.ReturnValue as Task;
                    if (task != null)
                    {
                        invocation.ReturnValue = task.ContinueWith(t => {
                            if (t.IsFaulted)
                            {
                                transactionScope.Dispose();
                                invocation.ReturnValue = t.Exception.Message;
                            }
                            else
                            {
                                transactionScope.Complete();
                            }
                        });
                    }
                    else
                    {
                        transactionScope.Complete();
                    }
                }
                catch (System.Exception e)
                {
                    transactionScope.Dispose();
                    invocation.ReturnValue = new ErrorResult(e.Message);
                }
            }
        }
    }
}

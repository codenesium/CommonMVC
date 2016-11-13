using Autofac.Extras.NLog;
using System.Data.Entity;
using System;
using Codenesium.JWTSessionAuth;

namespace Codenesium.Foundation.CommonMVC
{
    /// <summary>
    /// Controllers that need session authentication and transaction support should
    /// inherit from this class
    /// </summary>
    public abstract class AbstractSecureController : AbstractEntityFrameworkController
    {
        private Session _session { get; set; }

        public AbstractSecureController(
            ILogger logger,
            DbContext context
            ) : base(logger, context)
        {
        }

        public new Session Session
        {
            get
            {
                return this._session;
            }
            set
            {
                this._session = value;
            }
        }
    }
}
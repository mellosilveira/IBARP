using System.Collections.Generic;
using System.Net;

namespace IBARP.DataContracts.OperationBase
{
    /// <summary>
    /// It represents the response content for all operations.
    /// </summary>
    public abstract class OperationResponseBase
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        public OperationResponseBase()
        {
            this.ErrorMessages = new List<string>();
        }

        /// <summary>
        /// The success status of operation.
        /// </summary>
        public bool Success { get; protected set; }

        /// <summary>
        /// The HTTP status code.
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; protected set; }

        /// <summary>
        /// The list of error message.
        /// </summary>
        public List<string> ErrorMessages { get; protected set; }

        /// <summary>
        /// This method adds an error message to response.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="httpStatusCode"></param>
        public void AddError(string errorMessage, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest)
        {
            this.ErrorMessages.Add(errorMessage);

            this.HttpStatusCode = httpStatusCode;
            this.Success = false;
        }

        /// <summary>
        /// This method adds multiple error messages.
        /// </summary>
        /// <param name="errorMessagess"></param>
        /// <param name="httpStatusCode"></param>
        public void AddErrors(List<string> errorMessagess, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest)
        {
            this.ErrorMessages.AddRange(errorMessagess);

            this.HttpStatusCode = httpStatusCode;
            this.Success = false;
        }

        /// <summary>
        /// This method sets Success to true and the HttpStatusCode to 200 (OK).
        /// </summary>
        public void SetSuccessOk() => this.SetSuccess(HttpStatusCode.OK);

        /// <summary>
        /// This method sets Success to true and the HttpStatusCode to 201 (Created).
        /// </summary>
        public void SetSuccessCreated() => this.SetSuccess(HttpStatusCode.Created);

        /// <summary>
        /// This method sets Success to true and the HttpStatusCode to 202 (Accepted).
        /// </summary>
        public void SetSuccessAccepted() => this.SetSuccess(HttpStatusCode.Accepted);

        /// <summary>
        /// This method sets Success to false and the HttpStatusCode to 400 (BadRequest).
        /// </summary>
        /// <param name="errorMessage"></param>
        public void SetBadRequestError(string errorMessage = null) => this.SetError(HttpStatusCode.BadRequest, errorMessage);

        /// <summary>
        /// This method sets Success to false and the HttpStatusCode to 401 (Unauthorized).
        /// </summary>
        /// <param name="errorMessage"></param>
        public void SetUnauthorizedError(string errorMessage = null) => this.SetError(HttpStatusCode.Unauthorized, errorMessage);

        /// <summary>
        /// This method sets Success to false and the HttpStatusCode to 404 (NotFound).
        /// </summary>
        /// <param name="errorMessage"></param>
        public void SetNotFoundError(string errorMessage = null) => this.SetError(HttpStatusCode.NotFound, errorMessage);

        /// <summary>
        /// This method sets Success to false and the HttpStatusCode to 500 (InternalServerError).
        /// </summary>
        /// <param name="errorMessage"></param>
        public void SetInternalServerError(string errorMessage = null) => this.SetError(HttpStatusCode.InternalServerError, errorMessage);

        /// <summary>
        /// This method sets Success to false and the HttpStatusCode to 501 (NotImplemented).
        /// </summary>
        /// <param name="errorMessage"></param>
        public void SetNotImplementedError(string errorMessage = null) => this.SetError(HttpStatusCode.NotImplemented, errorMessage);

        /// <summary>
        /// This method sets Sucess to true.
        /// </summary>
        /// <param name="httpStatusCode"></param>
        protected void SetSuccess(HttpStatusCode httpStatusCode)
        {
            this.HttpStatusCode = httpStatusCode;
            this.Success = true;
        }

        /// <summary>
        /// This method sets Success to false.
        /// </summary>
        /// <param name="httpStatusCode"></param>
        /// <param name="errorMessage"></param>
        protected void SetError(HttpStatusCode httpStatusCode, string errorMessage = null)
        {
            if (errorMessage != null)
                this.ErrorMessages.Add(errorMessage);

            this.HttpStatusCode = httpStatusCode;
            this.Success = false;
        }
    }

    /// <summary>
    /// It represents the response content for all operations.
    /// </summary>
    /// <typeparam name="TResponseData"></typeparam>
    public abstract class OperationResponseBase<TResponseData> : OperationResponseBase
        where TResponseData : class, new()
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        public OperationResponseBase()
        {
            this.ErrorMessages = new List<string>();
            this.Data = new TResponseData();
        }

        /// <summary>
        /// It represents the 'data' content of all operation response.
        /// </summary>
        public TResponseData Data { get; set; }
    }
}

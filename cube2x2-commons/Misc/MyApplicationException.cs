namespace Grayscale.Cube2X2Commons
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// このアプリケーションで発生した細かな例外。
    /// </summary>
    [Serializable]
    public class MyApplicationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MyApplicationException"/> class.
        /// </summary>
        public MyApplicationException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MyApplicationException"/> class.
        /// </summary>
        /// <param name="message">エラーメッセージ。</param>
        public MyApplicationException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MyApplicationException"/> class.
        /// </summary>
        /// <param name="message">エラーメッセージ。</param>
        /// <param name="innerException">内部の例外。</param>
        public MyApplicationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MyApplicationException"/> class.
        /// </summary>
        /// <param name="info">情報。</param>
        /// <param name="context">コンテキスト。</param>
        protected MyApplicationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}

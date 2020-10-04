using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SquareEquation {
    public class DiscriminantLessZeroException : Exception {
        public DiscriminantLessZeroException() {
        }

        public DiscriminantLessZeroException(string message) : base(message) {
        }

        public DiscriminantLessZeroException(string message, Exception innerException) : base(message, innerException) {
        }

        protected DiscriminantLessZeroException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}

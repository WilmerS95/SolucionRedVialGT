using System;
using System.ComponentModel;

namespace RedVialGT.Shared
{
    public class RutaDTOTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string)
            {
                string stringValue = (string)value;
                int idRuta;
                if (int.TryParse(stringValue, out idRuta))
                {
                    return new RutaDTO { IdRuta = idRuta };
                }
                else
                {
                    throw new ArgumentException("La cadena no representa un IdRuta válido.");
                }
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
}

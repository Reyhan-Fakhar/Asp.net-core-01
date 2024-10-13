using Project_02.Domain.ViewModels;
using System.Linq.Expressions;
using System.Reflection;

namespace Project_02.Application.Helper
{
    public static class LinqExtensions
    {

        public static IEnumerable<IEnumerable<TValue>> Chunk<TValue>(this IEnumerable<TValue> values, Int32 chunkSize)
        {
            if (values!=null&&!values.Any()&& chunkSize==0)
            {
                yield return values.ToList();
            }
            else
            {
                var valuesList = values.ToList();
                var count = valuesList.Count();
                for (var i = 0; i < (count / chunkSize) + (count % chunkSize == 0 ? 0 : 1); i++)
                {
                    yield return valuesList.Skip(i * chunkSize).Take(chunkSize);
                }
            }
        }


        public static List<int> ExtractNumbersFromString(this string input)
        {
            // حذف کاراکترهای غیرضروری از رشته
            string cleanInput = new string(input.Where(c => char.IsDigit(c) || c == ',').ToArray());

            // جداسازی اعداد به صورت جداگانه
            string[] numberStrings = cleanInput.Split(',');

            // تبدیل رشته‌های عددی به اعداد صحیح
            List<int> numbers = new List<int>();
            foreach (string numStr in numberStrings)
            {
                if (int.TryParse(numStr, out int num))
                {
                    numbers.Add(num);
                }
            }

            return numbers;
        }
        private static PropertyInfo GetOneToManyRelationships(Type _type , string name)
        {
            var properties = _type.GetProperties();
            var matchedProperty = properties.FirstOrDefault(p => p.Name == name);

            if (matchedProperty == null)
            {
                var collectionProps = from p in _type.GetProperties()
                                      where p.CustomAttributes.Any(attr => attr.AttributeType ==
                                      typeof(System.ComponentModel.DataAnnotations.Schema.ForeignKeyAttribute))

                                      select p;

                matchedProperty = collectionProps.FirstOrDefault(p => p.Name == name);

            }


            if (matchedProperty == null)
            {
                
            }

            return matchedProperty;
        }



        private static PropertyInfo GetPropertyInfo(Type objType, string name)
        {
            var properties = objType.GetProperties();
            var matchedProperty = properties.FirstOrDefault(p => p.Name == name);
            if (matchedProperty == null)
                throw new ArgumentException("name");

            return matchedProperty;
        }
        private static LambdaExpression GetOrderExpression(Type objType, PropertyInfo pi)
        {
            var paramExpr = Expression.Parameter(objType);
            var propAccess = Expression.PropertyOrField(paramExpr, pi.Name);
            var expr = Expression.Lambda(propAccess, paramExpr);
            return expr;
        }

        public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> query, string name)
        {
            var propInfo = GetPropertyInfo(typeof(T), name);
            var expr = GetOrderExpression(typeof(T), propInfo);

            var method = typeof(Enumerable).GetMethods().FirstOrDefault(m => m.Name == "OrderBy" && m.GetParameters().Length == 2);
            var genericMethod = method.MakeGenericMethod(typeof(T), propInfo.PropertyType);
            return (IEnumerable<T>)genericMethod.Invoke(null, new object[] { query, expr.Compile() });
        }
        public static IQueryable<T> OrderByDescending<T>(this IQueryable<T> query, string name)
        {
            var propInfo = GetPropertyInfo(typeof(T), name);
            var expr = GetOrderExpression(typeof(T), propInfo);

            var method = typeof(Queryable).GetMethods().FirstOrDefault(m => m.Name == "OrderByDescending" && m.GetParameters().Length == 2);
            var genericMethod = method.MakeGenericMethod(typeof(T), propInfo.PropertyType);
            return (IQueryable<T>)genericMethod.Invoke(null, new object[] { query, expr });
        }

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, string name, Sort order)
        {
            var propInfo = GetPropertyInfo(typeof(T), name);
            var expr = GetOrderExpression(typeof(T), propInfo);

            var method = typeof(Queryable).GetMethods().FirstOrDefault(m => (order.Equals(Sort.OrderBy) ? m.Name == Sort.OrderBy.ToString() :
                m.Name == Sort.OrderByDescending.ToString()) && m.GetParameters().Length == 2);

            var genericMethod = method.MakeGenericMethod(typeof(T), propInfo.PropertyType);
            return (IQueryable<T>)genericMethod.Invoke(null, new object[] { query, expr });
        }

        public static Sort ConvertDtOrderDirToSort(this DtOrderDir dir)
        {
            if (dir == DtOrderDir.Desc)
                return Sort.OrderByDescending;

            return Sort.OrderBy;
        }




    }
}

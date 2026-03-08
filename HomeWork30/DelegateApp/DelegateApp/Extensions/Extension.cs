namespace DelegateApp
{
    public static class EnumerableExtensions
    {
        // Метод расширения для поиска максимального элемента с использованием делегата
        public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (convertToNumber == null) throw new ArgumentNullException(nameof(convertToNumber));

            T maxElement = null;
            float maxValue = float.MinValue;
            bool isFirst = true;

            foreach (var item in collection)
            {
                if (item == null) continue;

                // Используем делегат для преобразования объекта в число
                float currentValue = convertToNumber(item);

                if (isFirst || currentValue > maxValue)
                {
                    maxValue = currentValue;
                    maxElement = item;
                    isFirst = false;
                }
            }

            return maxElement;
        }
    }
}
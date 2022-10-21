using System.Collections;
 using System.Collections.Generic;

 namespace ApiGateway.Library.Services.Utilities
{
    public class Array
    {
        public static dynamic ToObject(object array)
        {
            var jsonstring = Newtonsoft.Json.JsonConvert.SerializeObject(array);
            return Newtonsoft.Json.JsonConvert.DeserializeObject(jsonstring);
        }

        //public static function flatten(object array)
        //{

        //    return = [];
        //    array_walk_recursive(array, function(a) use(&return) {
        //        return[] = a;
        //    });

        //    return return;
        //}

        /**
         * @see  https://www.php.net/manual/en/function.array-merge-recursive.php#92195
        * array_merge_recursive does indeed merge arrays, but it converts values with duplicate
        * keys to arrays rather than overwriting the value in the first array with the duplicate
        * value in the second array, as array_merge does. I.e., with array_merge_recursive,
        * this happens (documented behavior):
        *
        * array_merge_recursive(array('key' => 'org value'), array('key' => 'new value'));
        *     => array('key' => array('org value', 'new value'));
        *
        * array_merge_recursive_distinct does not change the datatypes of the values in the arrays.
        * Matching keys' values in the second array overwrite those in the first array, as is the
        * case with array_merge, i.e.:
        *
        * array_merge_recursive_distinct(array('key' => 'org value'), array('key' => 'new value'));
        *     => array('key' => array('new value'));
        *
        * Parameters are passed by reference, though only for performance reasons. They're not
        * altered by this function.
        *
        * @param array array1
        * @param array array2
        * @return array
        * @author Daniel <daniel (at) danielsmedegaardbuus (dot) dk>
        * @author Gabriel Sobrinho <gabriel (dot) sobrinho (at) gmail (dot) com>
        */
        //public static void merge_recursive_distinct(array &array1, array &array2)
        //{
        //    merged = array1;

        //    foreach (array2 as key => &value) {
        //        if (is_array(value) && isset(merged[key]) && is_array(merged[key]))
        //        {
        //            merged[key] = self::merge_recursive_distinct(merged[key], value);
        //        }
        //        else
        //        {
        //            merged[key] = value;
        //        }
        //    }

        //    return merged;
        //}

        public static bool inMultidimensional<T>(IList<T> array, string key, object val)
        {


            //          array.Where(p =>).Where(p => p.Tenure > 5)
            //.Select(p => p.Nationality)
            //.ForEach(n =>
            //{
            //});


            return false;
        }


        public static IEnumerable SortBy(object array,string  key, bool keepIndex = false)
        {
//            if(Type.IsArray(array))
//            {
//                return default(IEnumerable); 
//            }

            var func = keepIndex ? "usort" : "uasort";

            
//            func(array, function(a, b) use(key) {
//                return a[key] - b[key];
//            });
            return null;
//            return array;
        }
    }
}

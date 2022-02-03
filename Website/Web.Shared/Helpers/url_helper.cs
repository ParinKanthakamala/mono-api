namespace Web.Shared.Helpers
{
    public static class url_helper
    {
        /**
         * Site URL
         *
         * Create a local URL based on your basepath. Segments can be passed via the
         * first parameter either as a string or an array.
         *
         * @param	string	uri
         * @param	string	protocol
         * @return	string
         */
        public static string site_url(this object source, string uri = "", object protocol = null)
        {
            //            return config.site_url(uri, protocol);
            return "";
        }


        // ------------------------------------------------------------------------


        /**
         * Base URL
         *
         * Create a local URL based on your basepath.
         * Segments can be passed in as a string or an array, same as site_url
         * or a URL to a file can be passed in, e.g. to an image file.
         *
         * @param	string	uri
         * @param	string	protocol
         * @return	string
         */
        public static string base_url(this object source, string route = "", object protocol = null)
        {
            // return SharePoint.Location + route;
            return "";
        }

        /**
         * Current URL
         *
         * Returns the full URL (including segments) of the page where this
         * public static string is placed
         *
         * @return	string
         */
        public static string current_url()
        {
            return ""; //
                       //            return CI.config.site_url(CI.uri.uri_string());
        }

        /**
         * URL String
         *
         * Returns the URI segments.
         *
         * @return	string
         */
        public static string uri_string()
        {
            return ""; //   return uri.uri_string();
        }

        /**
         * Index page
         *
         * Returns the "index_page" from your config file
         *
         * @return	string
         */
        public static string index_page()
        {
            return ""; //      return config.item('index_page');
        }

        /**
         * Anchor Link
         *
         * Creates an anchor based on the local URL.
         *
         * @param	string	the URL
         * @param	string	the link title
         * @param	mixed	any attributes
         * @return	string
         */
        public static string anchor(this object source, string uri = "", string title = "", string attributes = "")
        {
            //            title = (string) title;
            //
            //            site_url = is_array(uri)
            //                ? site_url(uri)
            //                : (preg_match('#^(\w+:)?//#i', uri) ? uri : site_url(uri));
            //
            //            if (title == "")
            //            {
            //                title = site_url;
            //            }
            //
            //            if (attributes != "")
            //            {
            //                attributes = _stringify_attributes(attributes);
            //            }

            return ""; //  return '<a href="'.site_url.'"'.attributes.'>'.title.'</a>';
        }

        /**
         * Anchor Link - Pop-up version
         *
         * Creates an anchor based on the local URL. The link
         * opens a new window based on the attributes specified.
         *
         * @param	string	the URL
         * @param	string	the link title
         * @param	mixed	any attributes
         * @return	string
         */
        public static string anchor_popup(this object source, string uri = "", string title = "", bool attributes = false)
        {
            //            title = (string) title;
            //            site_url = preg_match('#^(\w+:)?//#i', uri) ? uri : site_url(uri);
            //
            //            if (title == "")
            //            {
            //                title = site_url;
            //            }
            //
            //            if (attributes == false)
            //            {
            //                return '<a href="'.site_url.'" onclick="window.open(\"".site_url."', '_blank');
            //                return false;\">".title.'</a>';
            //            }
            //
            //            if (!is_array(attributes))
            //            {
            //                attributes = array(attributes);
            //
            //                // Ref: http://www.w3schools.com/jsref/met_win_open.asp
            //                window_name = '_blank';
            //            }
            //
            //            else if (!empty(attributes['window_name']))
            //            {
            //                window_name = attributes['window_name'];
            //                unset(attributes['window_name']);
            //            }
            //            else
            //            {
            //                window_name = '_blank';
            //            }
            //
            //            foreach (array ('width' => '800', 'height' => '600', 'scrollbars' => 'yes', 'menubar' => 'no', 'status' => 'yes', 'resizable' => 'yes', 'screenx' => '0', 'screeny' => '0') as key => val)
            //            {
            //                atts[key] = isset(attributes[key]) ? attributes[key] : val;
            //                unset(attributes[key]);
            //            }
            //
            //            attributes = _stringify_attributes(attributes);
            //
            //            return '<a href="'.site_url
            //                .'" onclick="window.open(\"".site_url."', '".window_name."', '"._stringify_attributes(atts, true)."');
            //            return false;\""
            //                .attributes.'>'.title.'</a>';
            return "";
        }

        /**
         * Mailto Link
         *
         * @param	string	the email address
         * @param	string	the link title
         * @param	mixed	any attributes
         * @return	string
         */
        public static string mailto(this object source, string email, string title = "", string attributes = "")
        {

            if (title == "")
            {
                title = email;
            }

            //            return "<a href='mailto:" + email + "'" + _stringify_attributes(attributes) + ">" + title + "</a>";
            return "";
        }

        /**
         * Encoded Mailto Link
         *
         * Create a spam-protected mailto link written in Javascript
         *
         * @param	string	the email address
         * @param	string	the link title
         * @param	mixed	any attributes
         * @return	string
         */
        public static string safe_mailto(this object source, string email, string title = "", string attributes = "")
        {


            if (string.IsNullOrEmpty(title))
            {
                title = email;
            }

            //            x = str_split('<a href="mailto:', 1);
            //
            //            for (i = 0, l = strlen(email); i < l; i++)
            //            {
            //                x[] = '|'.ord(email[i]);
            //            }
            //
            //            x[] = '"';
            //
            //            if (attributes != "")
            //            {
            //                if (is_array(attributes))
            //                {
            //                    foreach (attributes as key => val)
            //                    {
            //                        x[] = ' '.key.'="';
            //                        for (i = 0, l = strlen(val); i < l; i++)
            //                        {
            //                            x[] = '|'.ord(val[i]);
            //                        }
            //
            //                        x[] = '"';
            //                    }
            //                }
            //                else
            //                {
            //                    for (i = 0, l = strlen(attributes); i < l; i++)
            //                    {
            //                        x[] = attributes[i];
            //                    }
            //                }
            //            }
            //
            //            x[] = '>';
            //
            //            temp = array();
            //            for (i = 0, l = strlen(title); i < l; i++)
            //            {
            //                ordinal = ord(title[i]);
            //
            //                if (ordinal < 128)
            //                {
            //                    x[] = '|'.ordinal;
            //                }
            //                else
            //                {
            //                    if (count(temp) == 0)
            //                    {
            //                        count = (ordinal < 224) ? 2 : 3;
            //                    }
            //
            //                    temp[] = ordinal;
            //                    if (count(temp) == count)
            //                    {
            //                        number = (count == 3)
            //                            ? ((temp[0] % 16) * 4096) + ((temp[1] % 64) * 64) + (temp[2] % 64)
            //                            : ((temp[0] % 32) * 64) + (temp[1] % 64);
            //                        x[] = '|'.number;
            //                        count = 1;
            //                        temp = array();
            //                    }
            //                }
            //            }
            //
            //            x[] = '<';
            //            x[] = '/';
            //            x[] = 'a';
            //            x[] = '>';
            //
            //            x = array_reverse(x);
            //
            //            output = "<script type=\"text/javascript\">\n"
            //                ."\t//<![CDATA[\n"
            //                ."\tvar l=new Array();\n";
            //
            //            for (i = 0, c = count(x); i < c; i++)
            //            {
            //                output.= "\tl[".i."] = '".x[i]."';\n";
            //            }
            //
            //            output.= "\n\tfor (var i = l.length-1; i >= 0; i=i-1) {\n"
            //                ."\t\tif (l[i].substring(0, 1) === '|') document.write(\"&#\"+unescape(l[i].substring(1))+\";\");\n"
            //                ."\t\telse document.write(unescape(l[i]));\n"
            //                ."\t}\n"
            //                ."\t//]]>\n"
            //                .'</script>';
            //
            //            return output;
            return null;
        }

        /**
         * Auto-linker
         *
         * Automatically links URL and Email addresses.
         * Note: There's a bit of extra code here to deal with
         * URLs or emails that end in a period. We'll strip these
         * off and add them after the link.
         *
         * @param	string	the string
         * @param	string	the type: email, url, or both
         * @param	bool	whether to create pop-up links
         * @return	string
         */
        public static string auto_link(this object source, string str, string type = "both", bool popup = false)
        {
            // Find and replace any URLs.
            //            if (type != 'email' && preg_match_all('#(\w*://|www\.)[a-z0-9]+(-+[a-z0-9]+)*(\.[a-z0-9]+(-+[a-z0-9]+)*)+(/([^\s()<>;]+\w)?/?)?#i', str, matches, PREG_OFFSET_CAPTURE | PREG_SET_ORDER))
            //            {
            //                // Set our target HTML if using popup links.
            //                target = (popup) ? ' target="_blank" rel="noopener"' : "";
            //
            //                // We process the links in reverse order (last . first) so that
            //                // the returned string offsets from preg_match_all() are not
            //                // moved as we add more HTML.
            //                foreach (array_reverse (matches) as match)
            //                {
            //                    // match[0] is the matched string/link
            //                    // match[1] is either a protocol prefix or 'www.'
            //                    //
            //                    // With PREG_OFFSET_CAPTURE, both of the above is an array,
            //                    // where the actual value is held in [0] and its offset at the [1] index.
            //                    a = '<a href="'.(strpos(match[1][0], '/') ? "" : 'http://').match[0][0].'"'.target.'>'.match[0][0].'</a>';
            //                    str = substr_replace(str, a, match[0][1], strlen(match[0][0]));
            //                }
            //            }
            //
            //            // Find and replace any emails.
            //            if (type != 'url' && preg_match_all('#([\w\.\-\+]+@[a-z0-9\-]+\.[a-z0-9\-\.]+[^[:punct:]\s])#i', str, matches, PREG_OFFSET_CAPTURE))
            //            {
            //                foreach (array_reverse (matches[0]) as match)
            //                {
            //                    if (filter_var(match[0], FILTER_VALIDATE_EMAIL) != false)
            //                    {
            //                        str = substr_replace(str, safe_mailto(match[0]), match[1], strlen(match[0]));
            //                    }
            //                }
            //            }

            return str;
        }

        /**
         * Prep URL
         *
         * Simply adds the http:// part if no scheme is included
         *
         * @param	string	the URL
         * @return	string
         */
        public static string prep_url(this object source, string str = "")
        {
            //            if (str == 'http://' OR str == "")
            //            {
            //                return "";
            //            }
            //
            //            url = parse_url(str);
            //
            //            if (!url OR ! isset(url['scheme']))
            //            {
            //                return 'http://'.str;
            //            }

            return str;
        }

        /**
         * Create URL Title
         *
         * Takes a "title" string as input and creates a
         * human-friendly URL string with a "separator" string
         * as the word separator.
         *
         * @todo	Remove old 'dash' and 'underscore' usage in 3.1+.
         * @param	string	str		Input string
         * @param	string	separator	Word separator
         *			(usually '-' or '_')
         * @param	bool	lowercase	Whether to transform the output string to lowercase
         * @return	string
         */
        public static string url_title(this object source, string str, string separator = "-", bool lowercase = false)
        {
            if (separator == "dash")
            {
                separator = "-";
            }

            else if (separator == "underscore")
            {
                separator = "_";
            }

            //            q_separator = preg_quote(separator, '#');
            //
            //            trans = array(
            //                '&.+?;' => "",
            //            '[^\w\d _-]' => "",
            //            '\s + '	 => separator,
            //            '('.q_separator.')+' => separator
            //                );
            //
            //            str = strip_tags(str);
            //            foreach (trans as key => val)
            //            {
            //                str = preg_replace('#'.key.'#i'.(UTF8_ENABLED ? 'u' : ""), val, str);
            //            }
            //
            //            if (lowercase == true)
            //            {
            //                str = strtolower(str);
            //            }
            //
            //            return trim(trim(str, separator));
            return "";
        }

        /**
         * Header Redirect
         *
         * Header redirect in two flavors
         * For very fine grained control over headers, you could use the Output
         * Library's set_header() function.
         *
         * @param	string	uri	URL
         * @param	string	method	Redirect method
         *			'auto', 'location' or 'refresh'
         * @param	int	code	HTTP Response status code
         * @return	void
         */
        public static void redirect(this object source, string uri = "", string method = "auto", string code = null)
        {
            //            if (!preg_match('#^(\w+:)?//#i', uri))
            //            {
            //                uri = site_url(uri);
            //            }
            //
            //            // IIS environment likely? Use 'refresh' for better compatibility
            //            if (method == 'auto' && isset(_SERVER['SERVER_SOFTWARE']) && strpos(_SERVER['SERVER_SOFTWARE'], 'Microsoft-IIS') != false)
            //            {
            //                method = 'refresh';
            //            }
            //
            //            else if (method != 'refresh' && (empty(code)
            //
            //            OR ! is_numeric(code)))
            //            {
            //                if (isset(_SERVER['SERVER_PROTOCOL'], _SERVER['REQUEST_METHOD']) && _SERVER['SERVER_PROTOCOL'] == 'HTTP/1.1')
            //                {
            //                    code = (_SERVER['REQUEST_METHOD'] != 'GET')
            //                        ? 303 // reference: http://en.wikipedia.org/wiki/Post/Redirect/Get
            //                        : 307;
            //                }
            //                else
            //                {
            //                    code = 302;
            //                }
            //            }
            //
            //            switch (method)
            //            {
            //                case 'refresh':
            //                    header('Refresh:0;url='.uri);
            //                    break;
            //                default:
            //                    header('Location: '.uri, true, code);
            //                    break;
            //            }
            //
            //            exit;
        }
    }
}
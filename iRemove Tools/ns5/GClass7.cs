using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using CurlSharp;
using Jose;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.OpenSsl;

namespace ns5
{
	// Token: 0x02000029 RID: 41
	public class GClass7
	{
		// Token: 0x06000241 RID: 577 RVA: 0x00021CE0 File Offset: 0x0001FEE0
		public GClass7()
		{
			this.gclass18_0 = new GClass18();
			Curl.GlobalInit(3);
			this.rsacryptoServiceProvider_0 = new RSACryptoServiceProvider();
			this.rsacryptoServiceProvider_0.ImportParameters(this.method_10());
			this.rsa_0 = RSA.Create();
			this.rsa_0.ImportParameters(this.method_9());
		}

		// Token: 0x06000242 RID: 578 RVA: 0x00021D40 File Offset: 0x0001FF40
		public string method_0(string action, string error = "")
		{
			Dictionary<string, string> dictionary = this.method_11();
			dictionary.Add(this.gclass18_0.method_2("NLqXl40AKDWQmbd+SeVU0A=="), action);
			dictionary.Add(this.gclass18_0.method_2("uupHZcOj9ffET7eZimfMYg=="), error);
			return this.method_2(dictionary, null);
		}

		// Token: 0x06000243 RID: 579 RVA: 0x00021D8C File Offset: 0x0001FF8C
		public string method_1(string action, Dictionary<string, string> post, string error = "")
		{
			Dictionary<string, string> dictionary = this.method_11();
			dictionary.Add(this.gclass18_0.method_2("NLqXl40AKDWQmbd+SeVU0A=="), action);
			dictionary.Add(this.gclass18_0.method_2("uupHZcOj9ffET7eZimfMYg=="), error);
			return this.method_2(dictionary, post);
		}

		// Token: 0x06000244 RID: 580 RVA: 0x00021DD8 File Offset: 0x0001FFD8
		public string method_2(Dictionary<string, string> payload, Dictionary<string, string> post = null)
		{
			if (post != null)
			{
				foreach (string key in post.Keys.ToList<string>())
				{
					post[key] = this.method_12(post[key]);
				}
			}
			string str = JWT.Encode(payload, this.rsacryptoServiceProvider_0, 1, 5, null, null, null);
			string result;
			try
			{
				using (CurlEasy curlEasy = new CurlEasy())
				{
					string text = string.Empty;
					List<byte[]> contentBuffers = new List<byte[]>();
					curlEasy.Url = GClass14.string_78 + this.gclass18_0.method_2("0zaQ37XTw63cSRdzsd5Fag==") + str;
					curlEasy.WriteFunction = delegate(byte[] buf, int size, int nmemb, object data)
					{
						contentBuffers.Add(buf);
						return size * nmemb;
					};
					curlEasy.CaInfo = GClass8.String_0;
					curlEasy.Timeout = 80;
					curlEasy.ConnectTimeout = 10;
					curlEasy.SslVerifyPeer = true;
					curlEasy.SslVerifyhost = true;
					if (post != null)
					{
						string str2 = JWT.Encode(post, this.rsacryptoServiceProvider_0, 1, 5, null, null, null);
						string text2 = this.gclass18_0.method_2("0kRUtAwUWekWid0nndXJVA==") + str2;
						curlEasy.PostFields = text2;
						curlEasy.PostFieldSize = text2.Length;
					}
					CurlCode curlCode = curlEasy.Perform();
					if (curlCode > 0)
					{
						result = null;
					}
					else
					{
						byte[] bytes = GClass7.smethod_3(contentBuffers.ToArray());
						text = Encoding.UTF8.GetString(bytes);
						string text3 = JWT.Decode(text, this.rsa_0, null, null);
						result = text3;
					}
				}
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000245 RID: 581 RVA: 0x00021FD4 File Offset: 0x000201D4
		public string method_3(string blob)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary.Add(this.gclass18_0.method_2("RaIOeoDJhk5Jn0RM50fzjA=="), blob);
			string text = this.method_1(this.gclass18_0.method_2("8TCvQ3kLfBLXnzAjwMrVzw=="), dictionary, "");
			string result;
			if (!text.Contains("status") || !text.Contains("error"))
			{
				if ((text != null || text.Contains(this.gclass18_0.method_2("qMNtG7rbhz3dE9aly1ZmlZMBmoUaGN0AKGjl+M7FxlM="))) && text.Contains(this.gclass18_0.method_2("oMSdBDs2q8G0SqyEu85zUg==")))
				{
					Dictionary<string, string> dictionary2 = JsonConvert.DeserializeObject<Dictionary<string, string>>(text);
					result = dictionary2[this.gclass18_0.method_2("oMSdBDs2q8G0SqyEu85zUg==")];
				}
				else
				{
					result = null;
				}
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000246 RID: 582 RVA: 0x00022098 File Offset: 0x00020298
		public string method_4(string arg0, string arg1, string arg2, Dictionary<string, string> arg3)
		{
			string result;
			try
			{
				using (CurlEasy curlEasy = new CurlEasy())
				{
					GClass10 gclass = new GClass10();
					string text = gclass.method_0(GClass14.dictionary_0[this.gclass18_0.method_2("bmFiuOp9GuP/EQGI1JcxlA==")] + "," + GClass14.dictionary_0[this.gclass18_0.method_2("9RTu7arVM/dkUpIzP5i54g==")] + this.gclass18_0.method_2("7aQbLYcuN+cRSC3DfG65KJcMKnMqwIYfcYFZKo9JhjA="));
					CurlSlist curlSlist = new CurlSlist();
					curlSlist.Append("Auth: " + arg2);
					curlSlist.Append("Device-X: " + Convert.ToBase64String(GClass7.smethod_0(text)));
					if (arg3 != null)
					{
						foreach (string text2 in arg3.Keys.ToList<string>())
						{
							curlSlist.Append(text2 + ": " + arg3[text2]);
						}
					}
					List<byte[]> contentBuffers = new List<byte[]>();
					curlEasy.Url = this.gclass18_0.method_2("qLSjVX8ugowYNXA0As/TApmUu2+nljYur/oPZJj4xlM=") + arg0;
					curlEasy.WriteFunction = delegate(byte[] buf, int size, int nmemb, object data)
					{
						contentBuffers.Add(buf);
						return size * nmemb;
					};
					curlEasy.CaInfo = GClass8.String_0;
					curlEasy.Timeout = 80;
					curlEasy.ConnectTimeout = 10;
					curlEasy.SslVerifyPeer = false;
					curlEasy.SslVerifyhost = false;
					curlEasy.CustomRequest = "POST";
					if (arg1 != null)
					{
						curlEasy.PostFields = arg1;
						curlEasy.PostFieldSize = arg1.Length;
						curlSlist.Append("Content-Type: text/plain;charset=UTF-8");
					}
					else
					{
						curlEasy.PostFields = "";
					}
					curlEasy.HttpHeader = curlSlist;
					CurlCode curlCode = curlEasy.Perform();
					if (curlCode > 0)
					{
						result = null;
					}
					else
					{
						byte[] bytes = GClass7.smethod_3(contentBuffers.ToArray());
						string @string = Encoding.UTF8.GetString(bytes);
						result = @string;
					}
				}
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000247 RID: 583 RVA: 0x000222DC File Offset: 0x000204DC
		public int method_5()
		{
			int result;
			try
			{
				using (CurlEasy curlEasy = new CurlEasy())
				{
					List<byte[]> contentBuffers = new List<byte[]>();
					curlEasy.Url = this.gclass18_0.method_2("qLSjVX8ugowYNXA0As/TApPSmza3PYj9Jh8zCxJFI7Q=");
					curlEasy.WriteFunction = delegate(byte[] buf, int size, int nmemb, object data)
					{
						contentBuffers.Add(buf);
						return size * nmemb;
					};
					curlEasy.CaInfo = GClass8.String_0;
					curlEasy.Timeout = 80;
					curlEasy.ConnectTimeout = 10;
					curlEasy.SslVerifyPeer = false;
					curlEasy.SslVerifyhost = false;
					curlEasy.CustomRequest = "POST";
					curlEasy.PostFields = "";
					CurlCode curlCode = curlEasy.Perform();
					if (curlCode > 0)
					{
						result = 0;
					}
					else
					{
						result = curlEasy.ResponseCode;
					}
				}
			}
			catch
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x06000248 RID: 584 RVA: 0x000223B4 File Offset: 0x000205B4
		private static byte[] smethod_0(string text)
		{
			Func<char, int> parseNybble = (char c) => (int)((c < '0' || c > '9') ? (char.ToLower(c) - 'a' + '\n') : (c - '0'));
			return (from x in Enumerable.Range(0, text.Length / 2)
			select (byte)(parseNybble(text[x * 2]) << 4 | parseNybble(text[x * 2 + 1]))).ToArray<byte>();
		}

		// Token: 0x06000249 RID: 585 RVA: 0x00022420 File Offset: 0x00020620
		public void method_6()
		{
			this.rsacryptoServiceProvider_0 = new RSACryptoServiceProvider();
			this.rsacryptoServiceProvider_0.ImportParameters(this.method_8());
			this.rsa_0 = RSA.Create();
			this.rsa_0.ImportParameters(this.method_7());
		}

		// Token: 0x0600024A RID: 586 RVA: 0x00022468 File Offset: 0x00020668
		private RSAParameters method_7()
		{
			PemReader pemReader = new PemReader(new StringReader(this.gclass18_0.method_2("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")));
			object obj = pemReader.ReadObject();
			AsymmetricCipherKeyPair asymmetricCipherKeyPair = (AsymmetricCipherKeyPair)obj;
			RsaPrivateCrtKeyParameters rsaPrivateCrtKeyParameters = (RsaPrivateCrtKeyParameters)asymmetricCipherKeyPair.Private;
			RSAParameters rsaparameters = default(RSAParameters);
			rsaparameters.Modulus = rsaPrivateCrtKeyParameters.Modulus.ToByteArrayUnsigned();
			rsaparameters.Exponent = rsaPrivateCrtKeyParameters.PublicExponent.ToByteArrayUnsigned();
			rsaparameters.P = rsaPrivateCrtKeyParameters.P.ToByteArrayUnsigned();
			rsaparameters.Q = rsaPrivateCrtKeyParameters.Q.ToByteArrayUnsigned();
			rsaparameters.D = GClass7.smethod_1(rsaPrivateCrtKeyParameters.Exponent, rsaparameters.Modulus.Length);
			rsaparameters.DP = GClass7.smethod_1(rsaPrivateCrtKeyParameters.DP, rsaparameters.P.Length);
			rsaparameters.DQ = GClass7.smethod_1(rsaPrivateCrtKeyParameters.DQ, rsaparameters.Q.Length);
			rsaparameters.InverseQ = GClass7.smethod_1(rsaPrivateCrtKeyParameters.QInv, rsaparameters.Q.Length);
			return rsaparameters;
		}

		// Token: 0x0600024B RID: 587 RVA: 0x0002256C File Offset: 0x0002076C
		private RSAParameters method_8()
		{
			PemReader pemReader = new PemReader(new StringReader(this.gclass18_0.method_2("WWR41ArTPgV4frk2mB0WeLb4R5VmZVnsRkDIUGyvotfAkiNqLjbVCGhiyzapuQeQVQGHWDqg3cKdbbduLDNq4GXleIRSnf9AUMonUVXIarT87RcFvuUFUsj6ugO7b9WBXzhF9fZJVifNqwxq/QEvtYpfC/0S7YxGEgD3GKpoC2nVUBaN4lovpQ0j05ZuiyQW640nZDjjbZ4NeE8cStj8GCqvjhmOdjA45CQNDDwkhsG0Z3IluoPpQt53aOVLTBODO37CJGRY+BKtiEOSm+uoWEUtDZwJ2ShLYDfqrAEAsnH0VyLpeXOGEFPEQcA3jthIcNNH11xOubG05dncj4vrILL0ecfMCab38ViU4MGdKT6SOMrGFcWWgqSC7CioAjmPgqfD8MiFl5G0lioHtiUXs7VsBv+tY3br6Bt9X3AuKonQRpyiC2YdzljgWFeLJQFcTmZAOLAUhM4TefvHw9/Lav2190DXA2N128d9bot+jzuqrB+DwJVvQs1H/nru0MEz63PwPowMMxzViZIy19EHSUQYVtesn69pyUfPK5oyMRkEGl62LeLN1l/vRQ8Losj6imrmxHua+8gJSuMp1dzmpVrZuryvB699p8zJDeDxsWs2KY9DG0bbHR0virMQDUiqU9wnZE5jobQhKx3WhUDwIaCPB0C60hR1kEi+ErhXfZS3uEqo5qfJq+n6Kj3PKUNzBjkmYY4936PdrFzS7ds2eUQoZaWu14Iwk8MITEKAWZ4fqvQqefZj8mGeXOg+XI28lH1OyMd2+krsxzwzEfxV6kOrUPFkW4tPWn2SrKM6XtQX3ZCPFE/0NgNpeXLB0elZYAUMJ1Z5qO6t029nl6NEWLSZArp3d6GrrGaBVLjBzr5K6kIGzeDjB7LtC48EQM47iw6NsKZH4mxdgKP6k583oPPmuISnEz5W/hP4j7gUGhjn0uDH+ELPAkjypkJPMYZwMH4ar95q4rVHw3jBeNW7oXjTvYANupUxiHINxrFijX73hI7VNATTCytPgdm7InEqgOZOCsYdjYDIRD5U/+Ady85pgk0jpY4ddhQrmfT0ZWk=")));
			object obj = pemReader.ReadObject();
			AsymmetricKeyParameter asymmetricKeyParameter = (AsymmetricKeyParameter)obj;
			RsaKeyParameters rsaKeyParameters = (RsaKeyParameters)asymmetricKeyParameter;
			return new RSAParameters
			{
				Modulus = rsaKeyParameters.Modulus.ToByteArrayUnsigned(),
				Exponent = rsaKeyParameters.Exponent.ToByteArrayUnsigned()
			};
		}

		// Token: 0x0600024C RID: 588 RVA: 0x000225DC File Offset: 0x000207DC
		private RSAParameters method_9()
		{
			PemReader pemReader = new PemReader(new StringReader(this.gclass18_0.method_2("TQpJ2AFQLN0j9jd9iJD+I1Ats4ym1VvIZkbRF/mzZdaI7i+15yVqeu1T5WpLKvvdrzKhs08v0fTuZ38JiwXVeXN+9jcedQkrnZ//gz2gIYHr8wWI6IYB0XxrTGMVUvgsTKa/Kgg7/EDyxKvm7apUu42PRZPVY6H90hUAtTWP+EkWqUrIuqljJ0NN4L9nB/k7PMIaLBlfmdKxxsFo4oI8Bj10iIQTWHwT6if/MOwtZ9asJUlz12YfCN6wdHLcAucyhLtiHlKoMJR6H29NTZDWlRfXMKmMUnl8y7Z1POsf/Wfsu7HNcWY4yOkzFALPBnPrjQzinrVgbZ1p0KJEhnp5fIkBFdhdWM2Z5AvwcPmYHyrK113+ymulQTDLeLinpdSMok2+nLwf3ojof8hT1n5Ys1LG01Qne0e+qdVbFs6vBPxMdPtQmByxLvY8UfqOBNIQxrtRmU1k8mEeXwtqN/UbieSGuSTAMIZkY3Ayq3dkT5X5gW23X27S18rla3XRH7dDYkwEpC9CyZaN56wilVCa1HXDhuDprrAXRfjZhg4ljLEUpnI8/7nTkXITA1GcRbqG/5iu1wc4+s6Ca/4sBL7RfuXFmIqd/YlR0dgAJTLyGQ5Tt397Be/qrmTOWWPfyJ8/fsmgQYLNegpYQiGue9zj1IlIFIH3h5VMSx7phBAc9giqNbScmsQwZw6Ba8qNPCtVkHqwEUrGq1sak+EfPlx5fSuIn44NXkUMPpvvd9tsePZr0dkggVdSk5kifsXsQPM223fVtdgNlTbPEdORuLqTZHINmtgm0vHxwYvEeiUn8NTPpcHC53zeJunqhl4SDs8L89+iPRrSpOnYgoaSuH6qWq1n1gIvyHeQwFGP8N8XQVZh9pi//60EW1Njq8XwgMzB5RRcgEQut/mxMTrP5HVPcDGAWEzMViUHM667kVYpYpiiur875crqIis948ZfV1gQCR00rSOCLd0C2qp1qde9wPNHJMRubO54U6Yti/rwHZKxLXt0cWZLxdlWjcHAgjSMHwFYMIFPNJI6Y9+NL82gUxeuZ7XWviMPiGCblvQJI2B0CUeDPKhVHN3MoIVKeBQy7lRZaziR60z8QbaYj4EgwO3dxr4i6HyLwCQ/gjNFf1dNnzo2a+21ABxmyNS5XuqzLYNdaNisuoEGixZzN02dKU81VsJN29Fl7PHYfzyXsEnvhrUTPojQUlUFfREocJ/LcrMhWI/leklZDi49HLvAb85GvwujXxny/vNuy9xZEaBA3uxlwy1aNhbem+P8MTu2wmoZ/mqmI42XAaGQFZu2fqAwmlOPbf1FfDBBmsMqKAt2NCzGSGr0iJuETfiuItsmM8HKkbcY4EWpSvFYdgmWWX/N+Lbf3St6tQ/OJKChp0HDiE4Zz/cw1rJh3RNp8BIqiS+1VJULgGWGsdcporsuaBi9ARmAy7Bm9zgdA7PG7YRZW90LD+kZ4K3rV4qLisE5uKFZNso1x4TOHndIai/2IY6wOp6Hfkmd1Ds7QIDzO9pKS32eYATjaLl2NqOgwuDKDMDpQpMdvuiI2UCNPimVCKKRf9L3F+SM35TlstPQ9ivGRrWhFEVO4w+lUSUYJ9c4x3rJF/WwocG/PpY1eiBTWqjdqjvw6U4tFg5VT6t+cpzlHJyxk9S0TTu3Ty1AS1/9abdWeQ1JS0NlJdfyfP0gc6SFiP8YaT+/tRASrd9yFR0THCrQY36qp+QiFi1qwMqmsDq+LQmTcjsHwrA6IwZRAsE3T/0c7XZ3qcxImRFgJ/b25x0LWVGJVJvAFUNGveCj92eTBn1Pi7uJ4smCrUdp+IRJdOamtQjQG3B1v8DvW0syh8Qg8lmQC9QDTEBrjnObznrta1D4DVUqsseOF9tmfz6BYrw6VAmE9OLztzZiRxw5z8BBjRZtepSosQQ9TuFCw+AQi4djn7zbb+kyBwk5aYPtisEMIoYuXIv4WYWg2YRpBOzMyzP0XZSa3Z4OamkVgohzHzYXmwyFyTckMklaAi0wXnWoI7S32SaqTbXEkF7g0CeIokNmHsM+6TKesWf5WZyt8IDKhH8pelN+mDc3LZcXDFhSW8C6xQYFm0k8nRPhBjyqk0JZgP/Pk2dcGFdm0Dzf9r/9SazFzpyU4Zo80Bh9uDfYk5Xfnw+AHKASLzDA1ZoMk+B5tELB8HfCgZ7QCJ8GyUP/EvxN+nqgyYeVRT99egxNgyLFVJAk9hvNlLBGIZKQgYJc5zpZRCUh2kb6zOB4ipI9SwzZfF0XmJHXydKKXk809ZbEfxBWUwXuLa+zfLHV79XNPwo79WsxlwnIB8OSFoHIUMXL8yCpDnC6TzfrwpyLI1wBz2vASo4iIzRiZOXilceaRAOjkTsDGTIUNnsQkqzzmy2KfduB0IAb1In65nIfCVCxphcKQBpLtPkgVvWIz/wUqIOTheSVP4echqcsU5lGuUAe4+UH+vvDbIPEP8CV+gZc3P7vtQzguzen3skEsekED/GbWLCWDF/8g/Z2s3U9AyyMnM3a3dgQR5o0O8huOSUVd7TZ2U3TyXoHS7YM41Qv/tZGbs1N1I/owXbKnv9iubdYsV/nCtj9SCvujTXx0GnTugGCsXaYluxWCcnQ99x9RsoPCurUSJvtHJGoawjtHP9OEZW1quUcWe2tss6+0W37eG0fwNw2CaWZlU2LfUQxZOr8Mav8JGeNQfO9MVnogaiJHhK2xjTs428+9PiEUkYm4suFA0IzZ4j5NAwbm2gBgui26oPEvpdXfiRZBHVoMjLUU9VXOVRgkaMaXM+O6XPK1TiAKp26729ltywiOMzHWbjyqXrLnPq95nM6IUsSW/EkyG/bxFoQQ5qQCltQ1oJ8zI3CwS4b1ZwVHNnzwy35T+b2qtq/vgYteaYjOQmpINXk5TiEmzWEImpmGzF9Z8YI7958nipPwWkCyj45+hTPcMhH2Q8Maao3BlgIsIoxYNUi+VEgBwntd7b6AlYyg6aYyJIbNIZ7T+sYTjva7WLzTCttJAV/SiQdQSGUekC2Ylh/w+bMHX778/x7WxwUBETHNAfnYffyGHYs0aw2X/386AL7aPJXpGdsRfHl+UJVC9h4mlU13TSGMNobuI9Ai49iPkFz4+z/LqmR/pm5n9246JDyT7hnA6b43VzIkudPWhWsSSVBiT5vHIh1g9UbRpHC3zD3r2UGcXfa8EByKT21hsdgJ8DoFbld8TlhNuB+RysBqY11DUuFDgBO3ta2xsCKWGRYN2lHahlFgJUyxNjcTuo3vx39xEsIvsosmgYagPz+6nAPME+ksRgYwcI6fl5KEeecPSKqQ7kZnKNIRYqEXDmUA4Wh9L4eYQyWfMaNVIZ0VyCg152DS/2noo+pSHB1az0Zl+MN5JG6/OrwhvOvzEjYvf+pQiILWLnA/oStDzS0FbPSKobrA3XDCWh30GWogo6ylNoii5lJq6X330KDjiIQs25gw2aOGB5KvKBCoUcSxeNnQur9c1CSZbmhXicbXW5WJZzUyglRzr4P2omLoj9C0n6JNSWww1ifZhTt6PqjFLkijF9qw/twmTa5cD5nncegA3v89eenbi5+NFnwrbTlWQoWBBIRMJT5gxXa4xRSYAKT4/ZknVlpd76jhBX02Jg0/Y00IIEsLsFbALLF0VU03Eh+OyOvXwjAOiB1P7BXwPvJYjwgihbcvAOdzZGIHtPUWxQhgFNx2TyO5EODg/ogLCkbFSPkX1BxhCHgGXh8Cnwf1VAWM/6o/LbDwTKxLxe4KEdUX7bpq70kDj5gkWygvbdN0OggzBKgClaTqykiqgdHkPN1HtsUXCm5uEtXYvvf+J1qW8OqXyZVZTA6vphc/oKIX75uAi5Ig96+ZnlaPas8elgiAM7dZ8i8eAUFQTIKv3Ncj02RrBn982pTUR4NEHkehKL0b0O5bTTBUGFd6a4MSSYBtvSMZCnU9BFFHI0PjCcY4VXvb8l9qzBL2wKy85a7gU8j13AUQsneSxBGzqSVZtoIs+PMYuNj7xveOvqLzFLYV2cUuHIZbLkSFxZvWux7pJquzYaEf/deVIhusW6M/XaQT1SV/J2cHlYaqifzz2qa/x2ubJMrfiXd5lO0Xtts5BMaOfeVA1brL24JFDk48rnTARh4RGVWbnV2+BzcS+qsosaPr/0lubWMqDeT26LcGO7KX3//gThbIACMbF2XXnY3eLDHR43PLDji91YqSoHtzNILh0MATl2/kfAgh8ahCwSQtdBpbNb1bxs8aB1AXxk2hXOHcOX1q59SHnKrVD4dTlLtff4cgh8E+i4yTkbxrwfwd9VvfrpZmKEeF70EsNHopdJtR+9G+9P2UtInWsrU8ow=")));
			object obj = pemReader.ReadObject();
			AsymmetricCipherKeyPair asymmetricCipherKeyPair = (AsymmetricCipherKeyPair)obj;
			RsaPrivateCrtKeyParameters rsaPrivateCrtKeyParameters = (RsaPrivateCrtKeyParameters)asymmetricCipherKeyPair.Private;
			RSAParameters rsaparameters = default(RSAParameters);
			rsaparameters.Modulus = rsaPrivateCrtKeyParameters.Modulus.ToByteArrayUnsigned();
			rsaparameters.Exponent = rsaPrivateCrtKeyParameters.PublicExponent.ToByteArrayUnsigned();
			rsaparameters.P = rsaPrivateCrtKeyParameters.P.ToByteArrayUnsigned();
			rsaparameters.Q = rsaPrivateCrtKeyParameters.Q.ToByteArrayUnsigned();
			rsaparameters.D = GClass7.smethod_1(rsaPrivateCrtKeyParameters.Exponent, rsaparameters.Modulus.Length);
			rsaparameters.DP = GClass7.smethod_1(rsaPrivateCrtKeyParameters.DP, rsaparameters.P.Length);
			rsaparameters.DQ = GClass7.smethod_1(rsaPrivateCrtKeyParameters.DQ, rsaparameters.Q.Length);
			rsaparameters.InverseQ = GClass7.smethod_1(rsaPrivateCrtKeyParameters.QInv, rsaparameters.Q.Length);
			return rsaparameters;
		}

		// Token: 0x0600024D RID: 589 RVA: 0x000226E0 File Offset: 0x000208E0
		private RSAParameters method_10()
		{
			PemReader pemReader = new PemReader(new StringReader(this.gclass18_0.method_2("WWR41ArTPgV4frk2mB0WeBE2YyjhSfWyzvhu6HoHyqcxV7UeRbiSJtfeXwVxFe6UK/UneCY334K8EV19vSQsBIIeI9vE6j1zzYnC5lH03FxRF2Og9lH19Y9cmfArY/yozI/Sy6wlnFGF8I6bFP8c0lsb9L6aL66N4rglnr/clciMU4MPDiasZWibbPftXTwA+k0QYntushalEP1fUetUTx58SfZ7amh+GpJPJaeDbv160iWD3fhhEakqqP6bNXTQdwh02HELNuk4jKuRejmLWncgeab+G0FO5XEx16TFHHTGWckWGVqY8ypgzBcaIfQ6JFU6LrraEWM8SBpLyODSHel/A0dcCw1eoIuwWtcUQpUCjcYZCDfIw0XPoNRKx19FiFVZAY/EPDikwCCMsTiYyc1LI4OJgpRNX/iHZCU+owVp/TPpuTZZWtiATjWH9FOM+A03kMpgcc1Ic8AFeJbC4RePVYpq69QKEaPAN9BYAH+rWqcBIvEAu/kFJ2l0++7glHEhlHSu+i1X3aWQgKG8qVuzfRmbbW6qiSHDZjjl5wBk/3utHPe5lXYU25Rb+l7YF4Nssmyycwq4Gx9cjE1LveWXMdnz0OLeWaIWnPyyTr5Mvl1lTQu2XW4pJC0PRIGDHEQVMKzdgDGg1WveY4ECCz9/cCCOUEA9LBisPfhqs3coamkeJDbfV/z32N9fCWOzdokpN7RKMP+evhIzoFFO9aDINObk7kaZ+Gcx2qv4uBDowMGRA7IuVVeP+tOpUmVN31nAcpS32OSs3IHB+jyl2+2Hag0u0ojKo4uCxN1yQdylL9Ti7Kp+USUjuPyClbo2ehjhctTIac86mqFoen9qyin388i1RwcEwST2yLvDOY85fJoaknn6tIoRm0+XIFVSrucbO0uNabU8hksPTDkP5yELj3vkHRJP/vH7DxDPeEYOxj8wybT48RSRoDLMopgHA2sGLDw5/TKeiTyQtXKviN7pcw47E7P1MVJ2TeFa4YlcOs+usswL8EMjfoLkdoXgBr8Ld6Yh1vyHWp6yGDVaLfojkj8Y4tIN0+YYHvk8IRdx54xhuI9genyCP282uS6O")));
			object obj = pemReader.ReadObject();
			AsymmetricKeyParameter asymmetricKeyParameter = (AsymmetricKeyParameter)obj;
			RsaKeyParameters rsaKeyParameters = (RsaKeyParameters)asymmetricKeyParameter;
			return new RSAParameters
			{
				Modulus = rsaKeyParameters.Modulus.ToByteArrayUnsigned(),
				Exponent = rsaKeyParameters.Exponent.ToByteArrayUnsigned()
			};
		}

		// Token: 0x0600024E RID: 590 RVA: 0x00022750 File Offset: 0x00020950
		private static byte[] smethod_1(BigInteger n, int size)
		{
			byte[] array = n.ToByteArrayUnsigned();
			byte[] result;
			if (array.Length == size)
			{
				result = array;
			}
			else
			{
				if (array.Length > size)
				{
					throw new ArgumentException("Specified size too small", "size");
				}
				byte[] array2 = new byte[size];
				Array.Copy(array, 0, array2, size - array.Length, array.Length);
				result = array2;
			}
			return result;
		}

		// Token: 0x0600024F RID: 591 RVA: 0x000227A4 File Offset: 0x000209A4
		private Dictionary<string, string> method_11()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>(GClass14.dictionary_0);
			if (GClass14.string_0 == null)
			{
				dictionary.Add(this.gclass18_0.method_2("9W2DjyUPRSjmbNTiQYInww=="), this.gclass18_0.method_2("Z9GBCHOOUHhAtoeBJsf2Jg=="));
			}
			else
			{
				dictionary.Add(this.gclass18_0.method_2("9W2DjyUPRSjmbNTiQYInww=="), GClass14.string_0);
			}
			dictionary.Add(this.gclass18_0.method_2("8Jl2ApLnZeExgu1ctpNVKQ=="), GClass14.string_77);
			dictionary.Add(this.gclass18_0.method_2("BsTuUb4fVMcpgEYzakRyFQ=="), GClass14.string_1);
			return dictionary;
		}

		// Token: 0x06000250 RID: 592 RVA: 0x00022844 File Offset: 0x00020A44
		private string method_12(string str)
		{
			string arg = string.Format("0-9a-zA-Z{0}", Regex.Escape("-_.!~*'()"));
			return Regex.Replace(str, string.Format("[^{0}]", arg), new MatchEvaluator(GClass7.smethod_2));
		}

		// Token: 0x06000251 RID: 593 RVA: 0x00022888 File Offset: 0x00020A88
		private static string smethod_2(Match match)
		{
			return (match.Value == " ") ? "+" : string.Format("%{0:X2}", Convert.ToInt32(match.Value[0]));
		}

		// Token: 0x06000252 RID: 594 RVA: 0x000228D0 File Offset: 0x00020AD0
		private static byte[] smethod_3(params byte[][] arrays)
		{
			byte[] array = new byte[arrays.Sum((byte[] x) => x.Length)];
			int num = 0;
			foreach (byte[] array2 in arrays)
			{
				Buffer.BlockCopy(array2, 0, array, num, array2.Length);
				num += array2.Length;
			}
			return array;
		}

		// Token: 0x04000110 RID: 272
		private GClass18 gclass18_0;

		// Token: 0x04000111 RID: 273
		private RSACryptoServiceProvider rsacryptoServiceProvider_0;

		// Token: 0x04000112 RID: 274
		private RSA rsa_0;

		// Token: 0x04000113 RID: 275
		private static readonly HttpClient httpClient_0 = new HttpClient();
	}
}

/*
	Created by Carl Emil Carlsen.
	Copyright 2016-2018 Sixth Sensor.
	All rights reserved.
	http://sixthsensor.dk
*/

using UnityEngine;

//namespace OscSimpl.Examples
//{
	public class GettingStartedReceiving : MonoBehaviour
	{
		[SerializeField] OscIn _oscIn;

		public string address1 = "/f7/f1";
		public string address2 = "/1/1";
        public string address3 = "/1/1";
        public string amouv = "/1/1";
        public string aaudio1 = "/1/1";
        public string arotation = "/1/1";
        public string azoom = "/1/1";
        public string ableu = "/1/1";
        public string acamer = "/1/1";
        public string aliquide = "/liquide";
    public string aliquide2 = "/liquide2";
    public string aliquide3 = "/liquide3";
    public string aaudio2 = "/audio2";
        public string alow = "/low";
        public string amid = "/mid";
        public string ahigh = "/high";
    public string alow2 = "/low2";
    public string amid2 = "/mid2";
    public string ahigh2 = "/high2";
    public string a2fac = "/2fac";
        float _incomingFloat;
        private int Nbr_portIn;
        public float address01 ;
        public float address02;
        public float address03;
        public float mouv;
        public float bleu;
        public float audio1;
        public float rotationv;
        public float zoom;
        public float camer;
    public float liquide;
    public float liquide2;
    public float liquide3;
    public float audio2;
    public float low;
    public float mid;
    public float high;
    public float low2;
    public float mid2;
    public float high2;
    public float fac2;

    void Start()
		{
            Nbr_portIn = _oscIn.port;
			// Ensure that we have a OscIn component and start receiving on port 7000.
			if( !_oscIn ) _oscIn = gameObject.AddComponent<OscIn>();
			_oscIn.Open( Nbr_portIn);

        }


		void OnEnable()
		{
            // You can "map" messages to methods in two ways:

            // 1) For messages with a single argument, route the value using the type specific map methods.
            /////// EVENEMENT MAPPING_oscIn.MapFloat( address1, Event1 );
            _oscIn.MapFloat(address1, Event1);
            _oscIn.MapFloat(address2, Event2);
            _oscIn.MapFloat(address3, Event3);
            _oscIn.MapFloat(aaudio1, Event4);
            _oscIn.MapFloat(arotation, Event5);
            _oscIn.MapFloat(azoom, Event6);
            _oscIn.MapFloat(ableu, Event7);
            _oscIn.MapFloat(amouv, Event8);
            _oscIn.MapFloat(acamer, Event9);
            _oscIn.MapFloat(aliquide, Event10);
            _oscIn.MapFloat(aaudio2, Event11);
            _oscIn.MapFloat(alow, Event12);
            _oscIn.MapFloat(amid, Event13);
            _oscIn.MapFloat(ahigh, Event14);
            _oscIn.MapFloat(a2fac, Event15);
        _oscIn.MapFloat(aliquide2, Event16);
        _oscIn.MapFloat(aliquide3, Event17);
        _oscIn.MapFloat(alow2, Event18);
        _oscIn.MapFloat(amid2, Event19);
        _oscIn.MapFloat(ahigh2, Event20);
        // 2) For messages with multiple arguments, route the message using the Map method.
        //_oscIn.Map( address2, OnCusto );
    }


		void OnDisable()
		{
			// If you want to stop receiving messages you have to "unmap".
			//_oscIn.UnmapFloat( OnTest1 );
			_oscIn.Unmap( OnTest2 );
		}
        void Test1(OscMessage incomingMessage)
        {
            if (incomingMessage.TryGet(0, out _incomingFloat))
            {
                Debug.Log("ConditionOk");
            }
          //  Debug.Log("Received f7/f1" + "\n");
            
        }

        void Event1( float value )
		{
            
          //  Debug.Log( "Received f7/f1" + value + "\n" );
            address01 = value;
		}
        void Event2(float value)
        {

         //   Debug.Log("Received f7/f1" + value + "\n");
            address02 = value;
        }
        void Event3(float value)
        {

          //  Debug.Log("Received f7/f1" + value + "\n");
            address03 = value;
        }
        void Event4(float value)
        {
           audio1  = value;
        }
        void Event5(float value)
        {
           rotationv  = value;
        }
        void Event6(float value)
        {
           zoom  = value;
        }
        void Event7(float value)
        {
           bleu  = value;
        }
        void Event8(float value)
        {
           mouv  = value;
        }
        void Event9(float value)
        {
           camer  = value;
        }
    void Event10(float value)
    {
        liquide = value;
    }
    void Event11(float value)
    {
        audio2 = value;
    }
    void Event12(float value)
    {
        low = value;
    }
    void Event13(float value)
    {
        mid = value;
    }
    void Event14(float value)
    {
        high = value;
    }
    void Event15(float value)
    {
         fac2 = value;
    }
    void Event16(float value)
    {
        liquide2 = value;
    }
    void Event17(float value)
    {
        liquide3 = value;
    }
    void Event18(float value)
    {
        low2 = value;
    }
    void Event19(float value)
    {
        mid2 = value;
    }
    void Event20(float value)
    {
        high2 = value;
    }
    void OnTest2( OscMessage message )
		{
            // Get arguments from index 0, 1 and 2 safely.
            float TestCelia;
			//int frameCount;
			//float time;
			//float random;
			if(
				message.TryGet( 0, out TestCelia ) 
				//message.TryGet( 1, out time ) &&
				//message.TryGet( 2, out random )
			) {
                //Debug.Log( "f7/f2" + TestCelia + " " + time + " " + random + "\n" );
                Debug.Log(TestCelia);
			}

			// If you don't know what type of arguments to expect, then you 
			// can check the type of each argument and get the ones you need.
			/*for( int i = 0; i < message.Count(); i++ )
			{
				OscArgType argType;
				if( !message.TryGetArgType( i, out argType ) ) continue;

				switch( argType )
				{
					case OscArgType.Float:
						float floatValue;
						message.TryGet( i, out floatValue );
						// Do something with floatValue here...
						break;
					case OscArgType.Int:
						int intValue;
						message.TryGet( i, out intValue );
						// Do something with intValue here...
						break;
				}
                
			}*/

			// Always recycle incoming messages when used.
			OscPool.Recycle( message );
		}
	}
//}
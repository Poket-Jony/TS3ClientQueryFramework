namespace TS3ClientQueryFramework.TS3Models
{
    public enum Codec
    {
        CODEC_SPEEX_NARROWBAND = 0, // 0: speex narrowband (mono, 16bit, 8kHz)
        CODEC_SPEEX_WIDEBAND = 1, // 1: speex wideband (mono, 16bit, 16kHz)
        CODEC_SPEEX_ULTRAWIDEBAND = 2, // 2: speex ultra-wideband (mono, 16bit, 32kHz)
        CODEC_CELT_MONO = 3 // 3: celt mono (mono, 16bit, 48kHz)
    };
}

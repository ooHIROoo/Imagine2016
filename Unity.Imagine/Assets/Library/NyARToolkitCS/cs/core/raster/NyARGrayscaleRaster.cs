/* 
 * PROJECT: NyARToolkitCS
 * --------------------------------------------------------------------------------
 *
 * The NyARToolkitCS is C# edition NyARToolKit class library.
 * Copyright (C)2008-2012 Ryo Iizuka
 *
 * This work is based on the ARToolKit developed by
 *   Hirokazu Kato
 *   Mark Billinghurst
 *   HITLab, University of Washington, Seattle
 * http://www.hitl.washington.edu/artoolkit/
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as publishe
 * by the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Lesser General Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 * 
 * For further information please contact.
 *	http://nyatla.jp/nyatoolkit/
 *	<airmail(at)ebony.plala.or.jp> or <nyatla(at)nyatla.jp>
 * 
 */
using System;
using System.Diagnostics; 
namespace NyAR.Core
{


    /**
     * このクラスは、グレースケース画像を格納するラスタクラスです。
     * 外部バッファ、内部バッファの両方に対応します。
     */
    public class NyARGrayscaleRaster : INyARGrayscaleRaster
    {
        protected NyARIntSize _size;
        protected int _buffer_type;
        /**
         * この関数は、ラスタの幅を返します。
         */
        public int getWidth()
        {
            return this._size.w;
        }
        /**
         * この関数は、ラスタの高さを返します。
         */
        public int getHeight()
        {
            return this._size.h;
        }
        /**
         * この関数は、ラスタのサイズを格納したオブジェクトを返します。
         */
        public NyARIntSize getSize()
        {
            return this._size;
        }
        /**
         * この関数は、ラスタのバッファへの参照値を返します。
         * バッファの形式は、コンストラクタに指定した形式と同じです。
         */
        public int getBufferType()
        {
            return _buffer_type;
        }
        /**
         * この関数は、ラスタの幅を返します。
         */
        public bool isEqualBufferType(int i_type_value)
        {
            return this._buffer_type == i_type_value;
        }
        public INyARGsPixelDriver getGsPixelDriver()
        {
            return this._pixdrv;
        }

        /** バッファオブジェクト*/
        protected object _buf;
        /** バッファオブジェクトがアタッチされていればtrue*/
        protected bool _is_attached_buffer;
        protected INyARGsPixelDriver _pixdrv;

        /**
         * コンストラクタです。
         * 内部参照のバッファ（{@link NyARBufferType#INT1D_GRAY_8}形式）を持つインスタンスを生成します。
         * @param i_width
         * ラスタのサイズ
         * @param i_height
         * ラスタのサイズ
         * @
         */
        public NyARGrayscaleRaster(int i_width, int i_height)
        {
            this._size = new NyARIntSize(i_width, i_height);
            this._buffer_type = NyARBufferType.INT1D_GRAY_8;
            initInstance(this._size, NyARBufferType.INT1D_GRAY_8, true);
        }
        /**
         * コンストラクタです。
         * 画像のサイズパラメータとバッファ参照方式を指定して、インスタンスを生成します。
         * バッファの形式は、{@link NyARBufferType#INT1D_GRAY_8}です。
         * @param i_width
         * ラスタのサイズ
         * @param i_height
         * ラスタのサイズ
         * @param i_is_alloc
         * バッファを外部参照にするかのフラグ値。
         * trueなら内部バッファ、falseなら外部バッファを使用します。
         * falseの場合、初期のバッファはnullになります。インスタンスを生成したのちに、{@link #wrapBuffer}を使って割り当ててください。
         * @
         */
        public NyARGrayscaleRaster(int i_width, int i_height, bool i_is_alloc)
        {
            this._size = new NyARIntSize(i_width, i_height);
            this._buffer_type = NyARBufferType.INT1D_GRAY_8;
            initInstance(this._size, NyARBufferType.INT1D_GRAY_8, i_is_alloc);
        }

        /**
         * コンストラクタです。
         * 画像のサイズパラメータとバッファ形式を指定して、インスタンスを生成します。
         * @param i_width
         * ラスタのサイズ
         * @param i_height
         * ラスタのサイズ
         * @param i_raster_type
         * ラスタのバッファ形式。
         * {@link NyARBufferType}に定義された定数値を指定してください。指定できる値は、以下の通りです。
         * <ul>
         * <li>{@link NyARBufferType#INT1D_GRAY_8}
         * <ul>
         * @param i_is_alloc
         * バッファを外部参照にするかのフラグ値。
         * trueなら内部バッファ、falseなら外部バッファを使用します。
         * falseの場合、初期のバッファはnullになります。インスタンスを生成したのちに、{@link #wrapBuffer}を使って割り当ててください。
         * @
         */
        public NyARGrayscaleRaster(int i_width, int i_height, int i_raster_type, bool i_is_alloc)
        {
            this._size = new NyARIntSize(i_width, i_height);
            this._buffer_type = i_raster_type;
            initInstance(this._size, i_raster_type, i_is_alloc);
        }

        /**
         * このクラスの初期化シーケンスです。コンストラクタから呼び出します。初期化に失敗すると、例外を発生します。
         * @param i_size
         * ラスタサイズ
         * @param i_raster_type
         * バッファ形式
         * @param i_is_alloc
         * バッファ参照方法値
         * @ 
         */
        protected virtual void initInstance(NyARIntSize i_size, int i_raster_type, bool i_is_alloc)
        {
            switch (i_raster_type)
            {
                case NyARBufferType.INT1D_GRAY_8:
                    this._buf = i_is_alloc ? new int[i_size.w * i_size.h] : null;
                    break;
                default:
                    throw new NyARException();
            }
            this._is_attached_buffer = i_is_alloc;
            //ピクセルドライバの生成
            this._pixdrv = NyARGsPixelDriverFactory.createDriver(this);
        }
        public virtual object createInterface(Type i_iid)
        {
            if (i_iid == typeof(NyARLabeling_Rle.IRasterDriver))
            {
                return NyARLabeling_Rle.RasterDriverFactory.createDriver(this);
            }
            if (i_iid ==typeof(NyARContourPickup.IRasterDriver))
            {
                return NyARContourPickup.ImageDriverFactory.createDriver(this);
            }
            if (i_iid == typeof(INyARHistogramFromRaster))
            {
                return NyARHistogramFromRasterFactory.createInstance(this);
            }
            throw new NyARException();
        }
        /**
         * この関数は、ラスタのバッファへの参照値を返します。
         * バッファの形式は、コンストラクタに指定した形式と同じです。
         */
        public object getBuffer()
        {
            return this._buf;
        }

        /**
         * この関数は、インスタンスがバッファを所有するかを返します。
         * 内部参照バッファの場合は、常にtrueです。
         * 外部参照バッファの場合は、バッファにアクセスする前に、このパラメタを確認してください。
         */
        public bool hasBuffer()
        {
            return this._buf != null;
        }
        /**
         * この関数は、ラスタに外部参照バッファをセットします。
         * 外部参照バッファを持つインスタンスでのみ使用できます。内部参照バッファを持つインスタンスでは使用できません。
         */
        public void WrapBuffer(object i_ref_buf)
        {
            Debug.Assert(!this._is_attached_buffer);// バッファがアタッチされていたら機能しない。
            //ラスタの形式は省略。
            this._pixdrv.switchRaster(this);
            this._buf = i_ref_buf;
        }

    }
}
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
namespace NyAR.Core
{

    public interface INyARGsPixelDriver
    {
        /**
         * この関数は、ピクセルドライバの参照する画像のサイズを返します。
         * @return
         * [readonly]
         */
        NyARIntSize getSize();
        void getPixelSet(int[] i_x, int[] i_y, int i_n, int[] o_buf, int i_st_buf);
        int getPixel(int i_x, int i_y);
        void switchRaster(INyARRaster i_ref_raster);
        bool isCompatibleRaster(INyARRaster i_raster);
        /**
         * この関数は、RGBデータを指定した座標のピクセルにセットします。 実装クラスでは、バッファにRGB値を書込む処理を実装してください。
         * 
         * @param i_x
         * 書込むピクセルの座標。画像の範囲内である事。
         * @param i_y
         * 書込むピクセルの座標。画像の範囲内である事。
         * @param i_rgb
         * 設定するピクセル値。
         * @
         */
        void setPixel(int i_x, int i_y, int i_gs);
        /**
         * この関数は、座標群にピクセルごとのRGBデータをセットします。 実装クラスでは、バッファにRGB値を書込む処理を実装してください。
         * 
         * @param i_x
         * 書き込むピクセルの座標配列。画像の範囲内である事。
         * @param i_y
         * 書き込むピクセルの座標配列。画像の範囲内である事。
         * @param i_intgs
         * 設定するピクセル値の数
         * @
         */
        void setPixels(int[] i_x, int[] i_y, int i_num, int[] i_intgs);
    }
}


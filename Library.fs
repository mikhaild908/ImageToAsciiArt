namespace ImageToAsciiArt

open System.Drawing

type AsciiArt() =
    static member ConvertToAscii (img:Bitmap) =
        let ascii = [|' '; '/'|]
        let chars = Array2D.zeroCreate img.Width img.Height
        for h in [0 .. img.Height - 1] do
            for w in [0 .. img.Width - 1] do
                let pixel = img.GetPixel(w, h)
                chars.[w, h] <- match pixel.R with 0uy -> ascii.[1] | _ -> ascii.[0]
        chars

    static member DrawText(text:string) : Bitmap =
        let bitmap = new Bitmap(24 * text.Length, 32)
        let graphics = Graphics.FromImage(bitmap)
        let brush = new SolidBrush(Color.Black)
        let font = new Font("Roboto Mono", 32.0f, FontStyle.Bold, GraphicsUnit.Pixel)
        graphics.FillRectangle(Brushes.White, new Rectangle(0, 0, bitmap.Width, bitmap.Height))
        graphics.DrawString(text, font, brush, new RectangleF(0.0f, -4.0f, 24.0f * (float32 text.Length), 32.0f))
        //bitmap.Save(text + ".png", Imaging.ImageFormat.Png)
        bitmap

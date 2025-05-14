using System.IO;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Path = System.IO.Path;

namespace LettreMotivGenerator.MVVM.Model;

public class Generator
{

    private string mainPath = Directory.GetCurrentDirectory();
    
    
    public void PdfGenerator(Myself myInfo, Company companyInfo, string? newPath)
    {
        if (newPath != null)
        {
            mainPath = newPath;
        }

        string fullPath = GenerateFullPath(companyInfo.CompanyName);

        using var writer = new PdfWriter(fullPath);
        using var pdf = new PdfDocument(writer);
        using (var doc = new Document(pdf, PageSize.A4))
        {
            doc.SetMargins(50, 50, 50, 50);
            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
            doc.SetFont(font);
            
            doc.Add(new Paragraph(myInfo.ToString())).SetTextAlignment(TextAlignment.LEFT).SetBottomMargin(20);
            
            doc.Add(new Paragraph(companyInfo.ToString())).SetTextAlignment(TextAlignment.RIGHT).SetBottomMargin(10);
            
            doc.Add(new Paragraph("Madame, Monsieur,")).SetTextAlignment(TextAlignment.LEFT).SetBottomMargin(10);

            string corps =
                @"Je vous écris pour exprimer ma candidature en alternance en tant que programmeur de jeux dans le cadre de mon Master avec l’ICAN.

Actuellement en échange international à l’UQAC en développement de jeux vidéo dans le cadre de ma troisième année de BUT Informatique, je souhaite poursuivre mes études dans ce domaine afin de parfaire ma connaissance du métier de programmeur.

Passionné de jeux vidéo depuis mon enfance, intégrer votre entreprise représente une étape cruciale pour concrétiser mon projet professionnel. Votre entreprise reconnue au niveau international serait une incroyable opportunité pour moi.

Ma formation à l’IUT et mon année au Québec m’ont permis d’apprendre de nombreuses compétences d’abord en développement d’application puis en développement de jeux vidéo notamment en gameplay et en réseau.

Ces expériences ont été très enrichissantes, et j’ai hâte d’en commencer une nouvelle.";

            foreach (string iPara in corps.Split("\n\n"))
            {
                doc.Add(new Paragraph(iPara.Trim())).SetTextAlignment(TextAlignment.JUSTIFIED).SetBottomMargin(10);
            }
            
            doc.Add(new Paragraph("Restant à votre disposition pour toute information complémentaire, je vous prie d’agréer l’expression de mes salutations distinguées."))
                .SetTextAlignment(TextAlignment.LEFT).SetBottomMargin(20);
            
            doc.Add(new Paragraph($"{myInfo.FirstName} {myInfo.LastName.ToUpper()}")).SetTextAlignment(TextAlignment.RIGHT);
        }

    }

    private string GenerateFullPath(string companyName)
    {
        return Path.Combine(mainPath, $"{companyName}.pdf");
    }
}
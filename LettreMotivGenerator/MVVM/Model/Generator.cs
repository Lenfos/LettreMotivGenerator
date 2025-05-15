using System.IO;
using iText.IO.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using Path = System.IO.Path;

namespace LettreMotivGenerator.MVVM.Model;

public class Generator
{

    private string mainPath = Directory.GetCurrentDirectory();
    string arialPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");

    
    
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
            PdfFont arial = PdfFontFactory.CreateFont(
                arialPath,
                PdfEncodings.WINANSI,
                PdfFontFactory.EmbeddingStrategy.PREFER_EMBEDDED
            );

            doc.SetFont(arial);

            Paragraph paragraph = new Paragraph(myInfo.ToString());
            paragraph.SetTextAlignment(TextAlignment.LEFT);
            paragraph.SetMultipliedLeading(1);
            paragraph.SetMarginBottom(10);
            doc.Add(paragraph).SetBottomMargin(20);

            paragraph = new Paragraph(companyInfo.ToString());
            paragraph.SetTextAlignment(TextAlignment.RIGHT);
            paragraph.SetMultipliedLeading(1);
            paragraph.SetMarginBottom(20);
            doc.Add(paragraph).SetTextAlignment(TextAlignment.RIGHT).SetBottomMargin(20);

            paragraph = new Paragraph("Madame, Monsieur,");
            paragraph.SetTextAlignment(TextAlignment.LEFT);
            doc.Add(paragraph).SetTextAlignment(TextAlignment.LEFT).SetBottomMargin(15);

            string corps =
                @"Je vous écris pour exprimer ma candidature en alternance en tant que programmeur de jeux dans le cadre de mon Master avec l’ICAN.

Actuellement en échange international à l’UQAC en développement de jeux vidéo dans le cadre de ma troisième année de BUT Informatique, je souhaite poursuivre mes études dans ce domaine afin de parfaire ma connaissance du métier de programmeur.

Passionné de jeux vidéo depuis mon enfance, intégrer votre entreprise représente une étape cruciale pour concrétiser mon projet professionnel. Votre entreprise reconnue au niveau international serait une incroyable opportunité pour moi.

Ma formation à l’IUT et mon année au Québec m’ont permis d’apprendre de nombreuses compétences d’abord en développement d’application puis en développement de jeux vidéo notamment en gameplay et en réseau.

Ces expériences ont été très enrichissantes, et j’ai hâte d’en commencer une nouvelle.";

            foreach (string iPara in corps.Split("\n"))
            {
                if (iPara == "" || iPara == "\n")
                {
                    continue;
                }
                Console.WriteLine(iPara.Trim());
                Console.WriteLine("---------------------");
                paragraph = new Paragraph(iPara.Trim());
                paragraph.SetMarginBottom(5);
                paragraph.SetTextAlignment(TextAlignment.JUSTIFIED);
                paragraph.SetFirstLineIndent(20);
                doc.Add(paragraph);
            }

            paragraph = new Paragraph(
                "Restant à votre disposition pour toute information complémentaire, je vous prie d’agréer l’expression de mes salutations distinguées.");
            paragraph.SetMarginBottom(20);
            paragraph.SetTextAlignment(TextAlignment.JUSTIFIED);
            paragraph.SetFirstLineIndent(20);
            doc.Add(paragraph);

            paragraph = new Paragraph($"{myInfo.FirstName} {myInfo.LastName.ToUpper()}");
            paragraph.SetTextAlignment(TextAlignment.RIGHT);
            paragraph.SetMarginTop(10);
            doc.Add(paragraph);
        }

    }

    private string GenerateFullPath(string companyName)
    {
        return Path.Combine(mainPath, $"Lettre_Motivation_{companyName}.pdf");
    }
}
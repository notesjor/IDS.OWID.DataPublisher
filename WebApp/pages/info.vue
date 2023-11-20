<template>
    <div style="margin:40px 0px 40px 0px; max-width: 72ch; text-align: justify;">
        <h1 id="annotationskategorien-und-spaltennamen">Annotationskategorien
            und Spaltennamen</h1>
        <ol type="1">
            <li>
                <p><strong>Pre</strong> Kontext vor dem Zieltoken. Umfasst
                    durchschnittlich 1-2 Sätze. Diese Spalte ist erst nach der Freischaltung
                    des vollständigen Datensatzes verfügbar.</p>
            </li>
            <li>
                <p><strong>Match</strong> Zieltoken. Die Treffer aus der
                    Korpusabfrage nach Komposita mit den Zweitgliedern <em>Gatte-Gatten</em>
                    bzw. <em>Gattin-Gattinnen</em> wurden manuell bereinigt, wobei folgende
                    Treffer entfernt wurden:</p>
                <ul>
                    <li>false positives wie <em>Regatte</em> und <em>Fregatte</em></li>
                    <li>Komposita, die keine Personenbezeichnung im Erstglied haben (z.B.
                        <em>Ehegattinnen</em>, <em>Mustergatte</em>)
                    </li>
                    <li>anthropomorphisierende Verwendungen zur Bezeichnung von Tieren (z.B.
                        <em>Pandagatte</em>, <em>Storchengattin</em>)
                    </li>
                    <li>Doppelungen der Belege Insgesamt enthält das hier zur Verfügung
                        gestellte Datenset nach der Bereinigung 12.047 Komposita.</li>
                </ul>
            </li>
            <li>
                <p><strong>Post</strong> Kontext nach dem Zieltoken. Umfasst
                    durchschnittlich 1-2 Sätze. Diese Spalte ist erst nach der Freischaltung
                    des vollständigen Datensatzes verfügbar.</p>
            </li>
            <li>
                <p><strong>Erstglied_Form</strong>: m, f, geschlechtsindefinit,
                    Eigenname, Akronym Hier wurde primär zwischen formal maskulinen (z.B.
                    <em>Anwalt</em>, <em>Lehrer</em>, <em>Millionär</em>; „m“) und formal
                    femininen (z.B. <em>Anglistin</em>, <em>Kanzlerin</em>,
                    <em>Filipina</em>; „f“) Personenbezeichnungen unterschieden. Hierunter
                    fallen auch sexusinhärente Lexeme, bei denen referenzielles und
                    lexikalisches Genus übereinstimmen. Das betrifft u.a.
                    Verwandtschaftsbezeichnungen wie <em>Mutter</em>, <em>Tochter</em>,
                    <em>Schwester</em> und <em>Bruder</em>, aber auch Frauenbezeichnungen
                    wie <em>Hausfrau</em>, <em>Hausmütterchen</em> und <em>Signora</em>.
                    Weitere Kategorien bilden geschlechtsunspezifische bzw. epizöne
                    Personenbezeichnungen (z.B. <em>Model</em>, <em>Monster</em>,
                    <em>Yuppie</em>; „geschlechtsindefinit“) sowie Eigennamen (z.B.
                    <em>Ankica</em>, <em>Hemingway</em>, <em>Poseidon</em>; „Eigenname“).
                    Außerdem gibt es zwei akronymische Formen (<em>OB</em> für
                    <em>Oberbürgermeister/in</em> sowie das englische <em>DJ</em> für
                    <em>Disc Jockey</em>; „Akronym“).
                </p>
            </li>
            <li>
                <p><strong>Erstglied_Numerus</strong>: sg, pl, pl? Hier wurde
                    annotiert, ob das Erstglied im Singular („sg“) oder im Plural („pl“)
                    steht. Bei zwei Belegen ist der Status unklar, aber eher pluralisch,
                    daher die Annotation „pl?“.</p>
            </li>
            <li>
                <p><strong>Erstglied_Ref_Gender</strong>: m, f, unklar, gn
                    Entsprechend der grundlegenden Unterscheidung zwischen
                    lexikalischem/grammatischem Geschlecht (Genus) und referenziellem
                    Geschlecht (Sexus/Gender), wurde zusätzlich das außersprachliche
                    Geschlecht der Referent<em>innen annotiert. Eine feinere Unterscheidung
                        zwischen Sexus (biologischem Geschlecht) und Gender (sozialem
                        Geschlecht) wurde nicht angesetzt, da non-binäre Referent</em>innen im
                    Datenset nicht vorkommen. Es wurden primär konkret weibliche
                    Referentinnen („f“) und konkret männliche Referenten („m“)
                    identifiziert. Generische Referenz, entweder auf eine
                    gemischtgeschlechtliche Gruppe oder auf ein Individuum, dessen
                    Geschlecht nicht relevant oder bekannt ist, ist selten (24 Tokens;
                    „gn“). Unklare Fälle sind ebenfalls selten (16 Tokens;
                    „unklar“).</p>
            </li>
            <li>
                <p><strong>Erstglied_Ref_Numerus</strong>: sg, pl Hier wurde
                    annotiert, ob das Erstglied auf eine Einzelperson („sg“) oder auf
                    mehrere Personen („pl“) referiert.</p>
            </li>
            <li>
                <p><strong>Zweitglied_Form</strong>: m, f, Doppelform Die Form des
                    Zweitglieds ist durch die Suchanfrage vorgegeben: Es handelt sich um
                    eine Form der Lexeme <em>Gatte</em> („m“) und <em>Gattin</em> („f“). Die
                    einzige Ausnahme besteht in einer Doppelform
                    (<em>Unternehmer-Gatten/Gattinnen</em>; „Doppelform“).</p>
            </li>
            <li>
                <p><strong>Zweitglied_Numerus</strong>: sg, pl Hier wurde annotiert,
                    ob das Zweitglied im Singular („sg“) oder im Plural („pl“)
                    steht.</p>
            </li>
            <li>
                <p><strong>Zweitglied_Ref_Gender</strong>: m, f, gn Wie bei den
                    Erstgliedern wurde für alle außersprachlichen Referent<em>innen der
                        Zweitglieder das Geschlecht bestimmt. Es liegt hier beinahe ausnahmslos
                        Genus-Sexus-Kongruenz vor, d.h. </em>Gatte* bezeichnet ausschließlich
                    Männer („m“) und <em>Gattin</em> ausschließlich Frauen („f“). Eine
                    generische bzw. geschlechtsübergreifende Verwendung findet sich nur bei
                    dem 24-mal als Zweitglied gebrauchten <em>Ehegatte</em> („gn“).</p>
            </li>
            <li>
                <p><strong>Zweitglied_Ref_Numerus</strong>: sg, pl Hier wurde
                    annotiert, ob das Zweitglied auf eine Einzelperson („sg“) oder auf
                    mehrere Personen („pl“) referiert.</p>
            </li>
            <li>
                <p><strong>Bedeutungsrelation</strong>: possessiv, qualifizierend,
                    unklar Hier wurde annotiert, welche Bedeutungsrelation bzw. Lesart beim
                    Kompositum vorliegt. Possessive Lesarten („possessiv“) liegen dann vor,
                    wenn ein Abhängigkeitsverhältnis kodiert wird, das mit einer
                    Genitivparaphrase umschrieben werden kann (z.B. <em>Arztgattin</em> =
                    <em>Gattin eines Arztes</em>). Ein qualifizierendes Verhältnis
                    („qualifizierend“) liegt vor, wenn Erst- und Zweitglied auf die gleiche
                    Person referieren und damit eine doppelte Individualisierung des
                    Referenten/der Referentin einhergeht (z.B. <em>Arztgatte</em> =
                    <em>Gatte, der gleichzeitig Arzt ist</em>). Die Relation lässt sich in
                    den meisten Fällen aus dem Kontext ableiten; unklare Fälle sind selten
                    (18 Tokens; „unklar“).
                </p>
            </li>
            <li>
                <p><strong>Fugenelement</strong>: ja, nein, unklar Hier wurde
                    annotiert, ob ein Fugenelement vorliegt („ja“) oder nicht („nein“). Als
                    Fugenelement werden Laute bzw. Lautverbindungen verstanden, die vom
                    Nominativ Singular des Erstglieds abweichen. Oft handelt es sich dabei
                    um paradigmatische Fugen, die dem Flexionsparadigma des Erstglieds
                    angehören, z.B. die <em>–(n)en</em>-Fuge in <em>Präsidentengattin</em>
                    oder <em>Bundesrätinnengatte</em>. Es finden sich aber auch die
                    unparadigmatisch Fugen, z.B. die s-Fuge in <em>Doktorinsgatte</em>.
                    Unklar ist der Status von Komposita, in denen das Erstglied eine
                    Pluralsemantik transportieren kann, was vor allem bei pluralischem
                    Zweitglied der Fall ist („unklar“), z.B. bei <em>Hausfrauengatten</em>
                    oder <em>Professorengattinnen</em>.</p>
            </li>
            <li>
                <p><strong>Bindestrich</strong>: ja, nein Zusätzlich wurde
                    annotiert, ob zwischen Erst- und Zweitglied ein Bindestrich steht („ja“)
                    oder nicht („nein“). Formen wie <em>US-Präsidentengattin</em> wurden
                    dementsprechend mit „nein“ annotiert, da sich der Bindestrich zwischen
                    Elementen des Erstglieds befindet.</p>
            </li>
            <li>
                <p><strong>Metasprachlicher Kommentar</strong>: ja, (Leere) Hier
                    wurde annotiert, ob es sich bei dem Beleg um einen metasprachlichen
                    Kommentar zum Thema <em>Gatte/Gattin</em> handelt („ja“). Ist dies nicht
                    der Fall, wurde die Spalte leergelassen.</p>
            </li>
            <li>
                <p><strong>Genusgleichheit_Kompositumsglieder</strong>: ja, nein, -
                    Basierend auf den Formen des Erst- und Zweitglieds wurde annotiert, ob
                    die Kompositumsglieder genuskongruent oder -divergent sind. Sind beide
                    Glieder formal maskulin bzw. feminin, wurde „ja“ annotiert, ansonsten
                    „nein“. Eigennamen im Erstglied bilden einen Spezialfall – hier wurde
                    das referenzielle Genus als Bezugsgröße gewählt, da das Genus eines
                    Namens dem biologischen Geschlecht des/der Benannten entspricht. So
                    wurde auch bei Akronymen verfahren. Problematisch ist in dieser
                    Annotationskategorie die Behandlung der geschlechtsunspezifischen
                    Personenbezeichnungen. Wie die formal maskulinen und femininen Nomen
                    haben sie ein eindeutiges grammatisches Genus; gleichzeitig ist dieses
                    nicht als Versprachlichung des biologischen Geschlechts des
                    Referenten/der Referentin zu verstehen, da die Begriffe
                    geschlechtsneutral bzw. -unspezifisch funktionieren (das Erstglied des
                    Kompositums <em>Weltstar-Gatte</em> kann demnach sowohl auf den Mann als
                    auch auf die Frau referieren, ohne dass ein Kongruenzbruch zwischen
                    Genus und Sexus entsteht). Ein Bezug auf das referenzielle Genus, wie es
                    bei Eigennamen problemlos möglich ist, ist ebenfalls problematisch, da
                    damit suggeriert wird, dass das grammatische Genus der Epikoina
                    keinerlei Rolle spielt. Da also keine der vorliegenden
                    Annotationskategorien als Bezugsgröße für die Frage nach Genusgleichheit
                    bzw. -divergenz der Glieder zielführend ist, werden
                    geschlechtsindefinite Erstglieder von dieser Annotationskategorie
                    ausgeschlossen („-“).</p>
            </li>
            <li>
                <p><strong>Generisches_Maskulinum_Erstglied</strong>: ja, nein,
                    unklar Es wurde annotiert, ob es sich beim Erstglied um ein
                    geschlechtsübergreifendes (bzw. generisches) Maskulinum handelt („ja“)
                    oder nicht („nein“). Unter einem geschlechtsübergreifenden Maskulinum
                    werden maskuline Formen verstanden, die auf gemischtgeschlechtliche
                    Gruppen oder geschlechtsunspezifisch referieren sollen. Bei diesen
                    Komposita liegt allerdings eine Sonderform vor: Die meisten
                    geschlechtsübergreifend maskulinen Erstglieder werden zur Referenz auf
                    (spezifische) Frauen verwendet, was als unüblich gilt. Unklare Fälle
                    sind selten (10 Tokens; „unklar“).</p>
            </li>
            <li>
                <p><strong>Erstglied</strong> Hier wurde die unflektierte und
                    unverfugte Form des Erstglieds im Nominativ Singular annotiert.</p>
            </li>
            <li>
                <p><strong>Medium, Jahr, Land</strong> Metadaten zu Medium (29
                    Zeitungen, Magazine, Online-Portale), Jahr (1986-2021) und Land
                    („Deutschland“, „Österreich“, „Schweiz“), aus denen der jeweilige Beleg
                    stammt.</p>
            </li>
            <li>
                <p><strong>Sigle, Titel, SatzID</strong> Metadaten zur Belegstelle
                    aus DeReKo.</p>
            </li>
        </ol>

    </div>
</template>

<style>
.content h1 {
    font-size: 1.875rem;
    line-height: 2.25rem;
    font-weight: 600;
}

.content h2 {
    font-size: 1.875rem;
    line-height: 2.25rem;
    font-weight: 400;
}

.content h3 {
    font-size: 1.5rem;
    line-height: 2rem;
    font-weight: 600;
}

.content h4 {
    font-size: 1.5rem;
    line-height: 2rem;
    font-weight: 400;
}

.content h5 {
    font-size: 1.25rem;
    line-height: 1.75rem;
    font-weight: 600;
}

.content h6 {
    font-size: 1.25rem;
    line-height: 1.75rem;
    font-weight: 400;
}

ol {
    margin-top: 10px
}

ol li {
    list-style: decimal;
    margin-left: 20px;
    margin-bottom: 20px;
}

ul li {
    list-style: disc;
    margin-left: 20px;
    margin-bottom: 0px;
}</style>
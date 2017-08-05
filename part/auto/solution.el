(TeX-add-style-hook
 "solution"
 (lambda ()
   (TeX-add-symbols
    "widthOfScalerStepFigure"
    "widthOfMatcherFigure")
   (LaTeX-add-labels
    "indexScript"
    "FlowMatcher"
    "scalerStep0"
    "scalerStep1"
    "scalerStep2"
    "matcherStep0"
    "matcherStep1"))
 :latex)


# Workflow de CI/CD

O utilizar o modelo um modelo de gestão de branchs baseado no **trunk-based**.

## Processo de lançamento de novas versões

1. Todo código desenvolvido é integrado na main.
   - Ao definir features para o próximo pacote, as branchers são mescladas na main.
   - Branch main pode conter código instável.
2. Iniciar branch release/x.x.x a partir da main.
   - Ajustar a versão no arquivo [src/Version.props](src/Version.props) - Deve ser coerente com o nome da branch, caso contrário o CI irá bloquear.
   - Efetuar ajustes se necessário para estabilização da versão.
   - Enquanto isso ocorre, não deve ser mesclado nada na main.
3. Ao realizar push da branch release:
   - Será publicada versão **preview no MyGet**.
   - Será aberta PR automática para a main.
4. Ao mesclar a PR na main:
   - Será publicada versão **oficial no Nuget**.
   - Build da versão ocorre com o commit id da branch release origem do merge, não com código da main.
   - Será criado release e tag no GitHub.

# Workflow de CI/CD

## Processo de lançamento de novas versões

1. Todo código desenvolvido é integrado na main.
   - Branch main pode conter código instável.
2. Após definido features do próximo pacote, é iniciada a branch release/x.x.x.
   - Ajustar a versão no arquivo [src/Version.props](src/Version.props).
   - Efetuar ajustes se necessário para estabilização da versão.
   - Enquanto isso ocorre, novas features podem ser integradas na main para a próxima versão.
3. Ao realizar push da branch release:
   - Será publicada versão preview no MyGet.
   - Será aberta PR automática para a main.
4. Ao mesclar a PR na main:
   - Será publicada versão oficial no Nuget.
   - Build da versão ocorre com o commit id da branch origem do merge.
   - A origem da PR será autotagada com a versão publicada.


## Branchs

- `main`: Pode conter código instável.
- `release/x.x.x`:
  - Estabilização da versão.
  - Alteração da tag `VersionPrefix`.
  - CI para publicar versão preview.
- Novas features devem ser iniciadas a partir da **main**.
- Correções emergencias devem iniciar a partir da ultima tag.

- teste
